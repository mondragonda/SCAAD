using SCAAD.APIs.Common;
using SCAAD.APIs.Logic.Business_Rules.PAAD;
using SCAAD.APIs.Logic.Interfaces;
using SCAAD.APIs.Models;
using SCAAD.APIs.Models.ViewModels;
using SCAAD.APIs.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SCAAD.APIs.Controllers
{
    [RoutePrefix("api/PAAD")]
    public class PAADController : CustomBaseController
    {
        public PAADController(IPAADLogic paadLogic)
        {
            this.paadLogic = paadLogic;
        }

        private readonly IPAADLogic paadLogic;

        public IHttpActionResult Get()
        {
            var PAADS = paadLogic.GetPAADs();

            if (PAADS.Count() == 0)
                return NotFound();

            return Ok(PAADS);
        }

        [Route("ObtenerPAAD/{numeroEmpleado}")]
        public IHttpActionResult GetPAADSByIdDocente([FromUri] int numeroEmpleado)
        {
            var PAADS = paadLogic.GetPAADs(numeroEmpleado);

            if (PAADS.Count() == 0)
                return NotFound();

            return Ok(PAADS);
        }

        [Route("AgregarPAAD/{idDocente}")]
        public IHttpActionResult Post([FromUri] string idDocente, [FromBody] PAADViewModel PAADViewModel)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    PAADViewModel.DocenteId = idDocente;

                    paadLogic.AddPAAD(idDocente, PAADViewModel);

                    return Ok(PAADSuceedMessages.RegistroPAADExitoso);

                }catch(InvalidOperationException e)
                {
                    return BadRequest(e.Message);
                }
            }

            return BadRequest(ControllerRequestErrorMessages.InvalidRequestInformation);
        }

        #if DEBUG
        [AllowAnonymous]
        #else
            [Authorize(Roles = Constants.Director)]
        #endif
        [Route("ModificarPAADSinJustificacion/{idPAAD}")]
        public IHttpActionResult Put([FromUri] int idPAAD, [FromBody] PAADViewModel PAADViewModel)
        {
            if(ModelState.IsValid)
            {
                try
                {

                    paadLogic.ModificarPAAD(idPAAD, PAADViewModel);

                    return Ok(PAADSuceedMessages.ModificacionPAADExitosa);

                }
                catch (ApplicationException e)
                {
                    return InternalServerError(e);
                }
            }

            return BadRequest(ControllerRequestErrorMessages.InvalidRequestInformation);
        }

        #if DEBUG
        [AllowAnonymous]
        #else
            [Authorize(Roles = Constants.Director)]
        #endif
        [Route("ModificarPAADConJustificacion/{idPAAD}")]
        public IHttpActionResult Put([FromUri] int idPAAD, [FromBody] PAADModificadoJustificadoViewModel PAADViewModel)
        {
            PAADViewModel.PAAD_Id = idPAAD;

            if (ModelState.IsValid)
            {
                paadLogic.ModificarPAADJustificada(idPAAD, PAADViewModel);

                return Ok("La modificación del PAAD se ha puesto en espera de aprobación por el director");
            }

            return BadRequest(ControllerRequestErrorMessages.InvalidRequestInformation);
        }


        #if DEBUG
        [AllowAnonymous]
        #else
            [Authorize(Roles = Constants.Director)]

        #endif
        [Route("GetPAADsEnEsperaParaAprobacion")]
        public IHttpActionResult GetPAADsRevisionAprobacion()
        {
            var PAADS = paadLogic.GetPAADsRevisionAprobacion();

            if (PAADS.Count() == 0)
                return NotFound();

            return Ok(PAADS);
        }

        #if DEBUG
        [AllowAnonymous]
        #else
            [Authorize(Roles = Constants.Director)]

        #endif
        [Route("GetPAADsConcluidos")]
        public IHttpActionResult GetPAADsCompletados()
        {
            var PAADS = paadLogic.GetPAADsCompletados();

            if (PAADS.Count() == 0)
                return NotFound();
            
            return Ok(PAADS);
        }   

        #if DEBUG
        [AllowAnonymous]
        #else
        [Authorize(Roles = Constants.Director)]
        #endif
        [HttpGet]
        [Route("GetPAADsEnEsperaAprobacionModificacion")]
        public IHttpActionResult GetPAADsAprobacionModificacion()
        {
            var PAADs = paadLogic.GetPAADsRevisionModificacion();

            if (PAADs.Count() == 0)
                return NotFound();

            return Ok(PAADs);
        }


        #if DEBUG
        [AllowAnonymous]
        #else
            [Authorize(Roles = Constants.Docente)]

        #endif
        [HttpPost]
        [Route("MandarPAADARevisionAprobacion/{PAAD_Id}")]
        public IHttpActionResult MandarPAADRevisionAprobacion([FromUri] int PAAD_Id)
        {
            paadLogic.MandarPAADRevisionAprobacion(PAAD_Id);
            return Ok();
        }

        #if DEBUG
        [AllowAnonymous]
        #else
            [Authorize(Roles = Constants.Director)]
        #endif
        [HttpPost]
        [Route("AprobarPAAD/{PAAD_Id}")]
        public IHttpActionResult AprobarPAAD([FromUri] int PAAD_Id)
        {
            paadLogic.AprobarPAAD(PAAD_Id);

            return Ok("El PAAD fue aprobado");
            
        }

        #if DEBUG
        [AllowAnonymous]
        #else
            [Authorize(Roles = Constants.Director)]
        #endif
        [HttpPost]
        [Route("RechazarPAAD/{PAAD_Id}")]
        public IHttpActionResult RechazarPAAD([FromUri] int PAAD_Id)
        {
            paadLogic.RechazarPAAD(PAAD_Id);

            return Ok("El PAAD fue rechazado");

        }

        #if DEBUG
        [AllowAnonymous]
        #else
            [Authorize(Roles = Constants.Director)]
        #endif
        [HttpPost]
        [Route("AprobarModificacionPAAD/{idPAADModificado}")]
        public IHttpActionResult AprobarModificacionPAAD([FromUri] int idPAADModificado)
        {
            paadLogic.AprobarModificacionPAAD(idPAADModificado);

            return Ok("La modificación pendiente se ha aplicado al PAAD");
        }
    }


}
