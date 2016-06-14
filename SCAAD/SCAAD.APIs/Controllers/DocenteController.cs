using System;
using System.Linq;
using System.Web.Http;
using SCAAD.APIs.Logic.Interfaces;
using System.Threading.Tasks;
using SCAAD.APIs.Logic.Business_Rules.Docente;
using SCAAD.APIs.Validators;
using SCAAD.APIs.Models.ViewModels;

namespace SCAAD.APIs.Controllers
{
#if DEBUG
    [AllowAnonymous]
#else
    [Authorize(Roles = SCAAD.APIs.Common.Constants.Docente)]
#endif
    [RoutePrefix("api/Docentes")]
    public class DocenteController : CustomBaseController
    {
        public DocenteController(IDocenteLogic docentesLogic)
        {
            this.docentesLogic = docentesLogic;
        }

        private readonly IDocenteLogic docentesLogic;

        [HttpGet]
        [Route("")]
        public IHttpActionResult Get()
        {
            var docentes = docentesLogic.GetDocentes();

            if (docentes.Count() == 0)
                return NotFound();

            return Ok(docentes);
        }

        [Route("InformacionDocente/{Usuario_Id}")]
        public async Task<IHttpActionResult> GetDocenteById(string Usuario_Id)
        {
            var user = await this.AppUserManager.FindByIdAsync(Usuario_Id);
            if (user == null || user.Docente_Id==null)
                return NotFound();
            var docente =  docentesLogic.GetDocente(user.Docente_Id);

            if (docente == null)
                return NotFound();

            return Ok(docente);
        }

        [Route("RegistrarInformacionDocente/{userId}")]
        public async Task<IHttpActionResult> Post([FromUri]string userId, [FromBody]DocenteViewModel docente)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    //var user = await this.AppUserManager.FindByIdAsync(userId);

                    await docentesLogic.AddDocente(AppUserManager, userId, docente);

                    return Ok(DocenteSucceedMessages.RegistroInformacionExitoso);
                }
                catch (InvalidOperationException e)
                {
                    return BadRequest(e.Message);
                }
            }
            else
            {
                return BadRequest(ControllerRequestErrorMessages.InvalidRequestInformation);
            }
        }


        [Route("ModificarInformacionDocente/{UserId}")]
        public async Task<IHttpActionResult> Put([FromUri]string UserId, [FromBody]DocenteModificarViewModel docente)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    docente.UserId = UserId;
                    await docentesLogic.ModificarDocente(docente);

                    return Ok(DocenteSucceedMessages.ModificacionInformacionExitoso);
                }
                catch (InvalidOperationException e)
                {
                    return BadRequest(e.Message);
                }
            }
            else
            {
                return BadRequest(ControllerRequestErrorMessages.InvalidRequestInformation);
            }
        }

    }
}
