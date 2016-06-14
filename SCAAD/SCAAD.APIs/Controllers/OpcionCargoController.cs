using SCAAD.APIs.Logic.Interfaces;
using SCAAD.APIs.Models;
using SCAAD.APIs.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SCAAD.APIs.Controllers
{
#if DEBUG
    [AllowAnonymous]
#else
    [Authorize(Roles = SCAAD.APIs.Common.Constants.Admin)]

#endif
    [RoutePrefix("api/OpcionesCargos")]
    public class OpcionCargoController : ApiController
    {
        public OpcionCargoController(IOpcionesCargoLogic opcionesCargoLogic)
        {
            this.opcionesCargoLogic = opcionesCargoLogic;
        }

        private readonly IOpcionesCargoLogic opcionesCargoLogic;

        [Route("")]
        public IHttpActionResult Get()
        {
            var opcionesCargos = opcionesCargoLogic.GetOpcionesCargos();

            if (opcionesCargos.Count() == 0)
                return NotFound();
            else
                return Ok(opcionesCargos);
        }

        [Route("RegistrarOpcionCargo")]
        public IHttpActionResult Post(OpcionesCargo opcionCargo)
        {
            if (ModelState.IsValid)
            {
                opcionesCargoLogic.AddOpcionCargo(opcionCargo);

                return StatusCode(HttpStatusCode.Created);
            }
            else
            {
                return BadRequest(ControllerRequestErrorMessages.InvalidRequestInformation);
            }
        }

        
    }
}
