using Microsoft.AspNet.Identity;
using SCAAD.APIs.Logic.Business_Rules.Auth;
using SCAAD.APIs.Logic.Interfaces;
using SCAAD.APIs.Models;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using SCAAD.APIs.Providers;
using SCAAD.APIs.Models.ViewModels;
using SCAAD.APIs.Validators;
using System;

namespace SCAAD.APIs.Controllers
{
    [RoutePrefix("api/Account")]
    public class AccountController : CustomBaseController
    {
        private IAuthLogic authLogic;

        public AccountController(IAuthLogic authLogic)
        {
            this.authLogic = authLogic;

        }
        [Route("users")]
        public IHttpActionResult GetUsers()
        {
            this.authLogic.iniciar(AppUserManager);
            return Ok(this.AppUserManager.Users.ToList().Select(u => this.authLogic.Create(u)));
        }

        [Route("user/{id:guid}", Name = "GetUserById")]
        public async Task<IHttpActionResult> GetUser(string Id)
        {
            var user = await this.AppUserManager.FindByIdAsync(Id);

            if (user != null)
            {
                this.authLogic.iniciar(AppUserManager);
                return Ok(this.authLogic.Create(user));
            }

            return NotFound();

        }

        [Route("user/{username}")]
        public async Task<IHttpActionResult> GetUserByName(string username)
        {
            var user = await this.AppUserManager.FindByNameAsync(username);

            if (user != null)
            {
                this.authLogic.iniciar(AppUserManager);
                return Ok(this.authLogic.Create(user));
            }

            return NotFound();

        }


        #if DEBUG
        [AllowAnonymous]
        #else
        [Authorize(Roles = SCAAD.Common.Constants.Admin)]
        #endif
        [Route("create")]
        public async Task<IHttpActionResult> CreateUser(CreateUserBindingModel usuarioNuevo)
        {
            
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = new Usuario()
            {
                UserName = usuarioNuevo.GetUsername(usuarioNuevo.Email),
                Email = usuarioNuevo.Email,
                Activo = true,
            };


            IdentityResult addUserResult = await this.AppUserManager.CreateAsync(user, usuarioNuevo.Password);



            if (!addUserResult.Succeeded)
            {
                return GetErrorResult(addUserResult);
            }

            var newUser = AppUserManager.FindByName(user.UserName);

            var addRolesResult = AppUserManager.AddToRoles(newUser.Id, new string[] { Common.Constants.Docente });

            if (!addRolesResult.Succeeded)
            {
                return GetErrorResult(addUserResult);
            }

            //EmailServiceGmail.SendEmail(user, "Usuario", "dedwew");
            
            return Ok();


        }


#if DEBUG
        [AllowAnonymous]
#else
        [Authorize(Roles = SCAAD.Common.Constants.Admin)]
#endif
        [Route("user/{id:guid}/roles")]
        [HttpPut]
        public async Task<IHttpActionResult> AssignRolesToUser([FromUri] string id, [FromBody] string[] rolesToAssign)
        {

            var appUser = await this.AppUserManager.FindByIdAsync(id);

            if (appUser == null)
            {
                return NotFound();
            }

            var currentRoles = await this.AppUserManager.GetRolesAsync(appUser.Id);

            var rolesNotExists = rolesToAssign.Except(this.AppRoleManager.Roles.Select(x => x.Name)).ToArray();

            if (rolesNotExists.Count() > 0)
            {

                ModelState.AddModelError("", string.Format("Roles '{0}' does not exixts in the system", string.Join(",", rolesNotExists)));
                return BadRequest(ModelState);
            }

            IdentityResult removeResult = await this.AppUserManager.RemoveFromRolesAsync(appUser.Id, currentRoles.ToArray());

            if (!removeResult.Succeeded)
            {
                ModelState.AddModelError("", "Failed to remove user roles");
                return BadRequest(ModelState);
            }

            IdentityResult addResult = await this.AppUserManager.AddToRolesAsync(appUser.Id, rolesToAssign);

            if (!addResult.Succeeded)
            {
                ModelState.AddModelError("", "Failed to add user roles");
                return BadRequest(ModelState);
            }

            return Ok();
        }



#if DEBUG
        [AllowAnonymous]
#else
        [Authorize(Roles = SCAAD.Common.Constants.Admin)]
#endif
        [HttpPost]
        [Route("cambiarEstatusUsuario")]
        public async Task<IHttpActionResult> CambiarEstatusUsuario([FromUri] string id)
        {
            var usuario = await this.AppUserManager.FindByIdAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }

            usuario.Activo = !usuario.Activo;
            var result =  AppUserManager.Update(usuario);

            if (!result.Succeeded)
            {
                return GetErrorResult(result);
            }
            return Ok();
        }
#if DEBUG
        [AllowAnonymous]
#else
        [Authorize(Roles = SCAAD.Common.Constants.Docente)]
#endif
        [HttpPost]
        [Route("CambiarActualPassword/{userId}")]
        public async Task<IHttpActionResult> CambiarActualPassword([FromUri]string userId, [FromBody]ChangePasswordModel changePasswordModel)
        {
            var currentPassword = changePasswordModel.currentPassword;

            var newPassword = changePasswordModel.newPassword;

            var identityResult = await authLogic.CambiarPassword(userId, currentPassword, newPassword);

            if (identityResult.Succeeded)
                return Ok();
            else
                return BadRequest(IdentityAuthErrorMessages.GetAppendedIdentityResultErrors(identityResult));
        }

#if DEBUG
        [AllowAnonymous]
#else
        [Authorize(Roles = SCAAD.APIs.Common.Constants.Admin)]
#endif
        [HttpPost]
        [Route("CambiarPassword")]
        public async Task<IHttpActionResult> CambiarPassword([FromBody]CambiarPasswordViewModel model)
        {
            var identityResult = await authLogic.CambiarPassword(model.UsuarioId, model.Password);

            if (identityResult.Succeeded)
                return Ok();
            else
                return BadRequest(IdentityAuthErrorMessages.GetAppendedIdentityResultErrors(identityResult));
        }

        [HttpPut]
        [Route("AsignarComoDirector/{userId}")]
        public  IHttpActionResult AsignarComoDirector([FromUri]string userId)
        {
            if (!string.IsNullOrEmpty(userId))
            {
                try
                {
                    authLogic.AsignarComoDirector(AppUserManager, AppRoleManager, userId);

                    return Ok("La asignación del nuevo director fue exitosa");

                }catch(Exception e)
                {
                    return InternalServerError(e);
                }
            }

           return BadRequest(ControllerRequestErrorMessages.InvalidRequestInformation);
              
        }

    }
}
