using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using SCAAD.APIs.Logic.Interfaces;
using SCAAD.APIs.Models;
using SCAAD.APIs.Data.Implementations;
using SCAAD.APIs.Data.Interfaces;
using System.Web.Http.Routing;
using System.Data.Entity;
using SCAAD.APIs.Data;
using System.Net.Http;
using SCAAD.APIs.Infrastructure;

namespace SCAAD.APIs.Logic.Implementations
{
    public class AuthLogic : IAuthLogic
    {
        private readonly IAuthRepository authRepository;
        private ApplicationUserManager _AppUserManager;


        public AuthLogic(IAuthRepository authRepository)
        {
            this.authRepository = authRepository;
        }

        public void Dispose()
        {
            authRepository.Dispose();
        }

        public Task<Usuario> FindUser(string userName, string password)
        {
            return authRepository.FindUser(userName, password);
        }

        public Task<IdentityResult> RegisterUser(UserModel userModel)
        {
            return authRepository.RegisterUser(userModel);
        }

        public Task<IdentityResult> CambiarPassword(string userId, string currentPassword, string newPassword)
        {
            var identityResult = authRepository.ChangePassword(userId, currentPassword, newPassword);

            return identityResult;
        }

        public Task<IdentityResult> CambiarPassword(string UserId, string Password)
        {
            var identityResult = authRepository.ChangePassword(UserId, Password);

            return identityResult;
        }

        public void iniciar(ApplicationUserManager appUserManager)
        {
            _AppUserManager = appUserManager;
        }

        public UserReturnModel Create(Usuario appUser)
        {
            return new UserReturnModel()
            {
                Id = appUser.Id,
                UserName = appUser.UserName,
                //FullName = string.Format("{0} {1}", app.Nombre, appUser.Apellido),
                IdDocente = appUser.Docente_Id,
                Email = appUser.Email,
                EmailConfirmed = appUser.EmailConfirmed,
                Activo = appUser.Activo,
                Roles = _AppUserManager.GetRolesAsync(appUser.Id).Result,
                Claims = _AppUserManager.GetClaimsAsync(appUser.Id).Result,
            };

        }

        public RoleReturnModel Create(IdentityRole appRole)
        {
            return new RoleReturnModel
            {
                Id = appRole.Id,
                Name = appRole.Name
            };
        }

        public void AsignarComoDirector(ApplicationUserManager userManager,
                                        ApplicationRoleManager roleManager, string userId)
        {
            var users = userManager.Users.ToList();

            foreach (var user in users)
            {
                var userRoles = userManager.GetRoles(user.Id).ToList();

                foreach (var role in userRoles)
                {
                    if (role == Common.Constants.Director)
                    {
                        try
                        {
                            userManager.RemoveFromRole(user.Id, Common.Constants.Director);
                            userManager.AddToRole(user.Id, Common.Constants.Docente);

                        }
                        catch (Exception e)
                        {
                            throw new ApplicationException("No se pudo realizar la desasignación del director actual. Ocurrió un error en el sistema");
                        }
                    }
                }
            }

            try
            {
                userManager.RemoveFromRole(userId, Common.Constants.Docente);
                userManager.AddToRole(userId, Common.Constants.Director);
            }catch(Exception e)
            {
                throw new ApplicationException("El director anterior fue desasignado, pero no se pudo asignar al nuevo director. Ocurrió un error en el sistema");
            }
        }

        public IEnumerable<string> GetRegisteredUserRoles(string userId)
        {
            return authRepository.GetRegisteredUserRoles(userId);
        }
    }
}