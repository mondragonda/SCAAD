using SCAAD.APIs.Logic.Business_Rules.PAADActividad;
using SCAAD.APIs.Logic.Interfaces;
using SCAAD.APIs.Models.ViewModels;
using SCAAD.APIs.Validators;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;

namespace SCAAD.APIs.Controllers
{
    [RoutePrefix("api/PAADActividad")]
    [AllowAnonymous]
    public class PAADActividadController : CustomBaseController
    {
        public PAADActividadController(IPAADActividadLogic PAADActividadLogic)
        {
            this.PAADActividadLogic = PAADActividadLogic;
        }

        private readonly IPAADActividadLogic PAADActividadLogic;

        [Route("ObtenerActividadesPAAD/{idPAAD}")]
        public IHttpActionResult Get([FromUri]int idPAAD)
        {
            var PAADActividades = PAADActividadLogic.GetPAADActividades(idPAAD);

            if (PAADActividades.Count() == 0)
                return NotFound();

            return Ok(PAADActividades); 
        }

        [Route("AgregarPAADActividad/{idPAAD}")]
        public IHttpActionResult Post([FromUri]int idPAAD, [FromBody]PAADActividadViewModel PAADActividadViewModel)
        {
            PAADActividadViewModel.idPAAD = idPAAD;

            if (ModelState.IsValid)
            {
                try
                {
                    PAADActividadLogic.AddPAADActividad(PAADActividadViewModel);

                    return Ok(PAADActividadSucceedMessages.RegistroPAADActividadExitoso);

                }catch(InvalidOperationException e)
                {
                    return BadRequest(e.Message);
                }
            }

            return BadRequest(ControllerRequestErrorMessages.InvalidRequestInformation);
        }
        [Route("ModificarActividad/{Actividad_Id}")]
        public IHttpActionResult ModificarActividad([FromUri]int Actividad_Id,[FromBody]PAADActividadViewModel actividadiewModel)
        {            

            if (ModelState.IsValid)
            {
                PAADActividadLogic.ModificarActividad(Actividad_Id, actividadiewModel);

                return Ok(PAADActividadSucceedMessages.ModificacionPAADActividadExitosa);
            }

            return BadRequest(ControllerRequestErrorMessages.InvalidRequestInformation);
        }

        [Route("ModificarActividadJustificada/{Actividad_Id}")]
        public IHttpActionResult ModificarActividadJustificada([FromUri]int Actividad_Id, [FromBody]ActividadModificadaViewModel actividadiewModel)
        {

            if (ModelState.IsValid)
            {
                PAADActividadLogic.ModificarActividadJustificada(Actividad_Id, actividadiewModel);

                return Ok(PAADActividadSucceedMessages.ModificacionPAADActividadExitosa);
            }

            return BadRequest(ControllerRequestErrorMessages.InvalidRequestInformation);
        }


        [HttpPut]
        [Route("CancelarActividad/{Actividad_Id}")]
        public IHttpActionResult CancelarActividad([FromUri]int Actividad_Id, [FromBody]ActividadCanceladaViewModel actividadCanceladaViewModel)
        {
            actividadCanceladaViewModel.Actividad_Id = Actividad_Id;

            if (ModelState.IsValid)
            {
                PAADActividadLogic.CancelarActividad(actividadCanceladaViewModel);

                return Ok(PAADActividadSucceedMessages.CancelacionActividadExitosa);
            }

            return BadRequest(ControllerRequestErrorMessages.InvalidRequestInformation);
        }

        [HttpPut]
        [Route("CompletarActividad/{Actividad_Id}")]
        public IHttpActionResult CompletarActividad([FromUri] int Actividad_Id,[FromBody]ActividadCompletadaViewModel model)
        {
            model.Actividad_Id = Actividad_Id;
            if (ModelState.IsValid)
            {
                PAADActividadLogic.CompletarActividad(model);

            }
            return BadRequest(ControllerRequestErrorMessages.InvalidRequestInformation);
        }





    }
}
