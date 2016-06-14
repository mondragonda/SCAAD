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
    [RoutePrefix("api/DescripcionesCargo")]

    public class DescripcionCargoController : ApiController
    {
        public DescripcionCargoController(IDescripcionCargoLogic descripcionesCargoLogic)
        {
            this.descripcionesCargoLogic = descripcionesCargoLogic;
        }

        private readonly IDescripcionCargoLogic descripcionesCargoLogic;
        [Route("")]
        public IHttpActionResult Get()
        {
            var descripcionesCargo = descripcionesCargoLogic.GetDescripcionesCargo();

            if (descripcionesCargo.Count() == 0)
                return NotFound();
            else
                return Ok(descripcionesCargo);
        }

        [Route("RegistrarDescripcionCargo")]
        public IHttpActionResult Post(DescripcionCargo descripcionCargo)
        {
            if(ModelState.IsValid)
            {
                descripcionesCargoLogic.AddDescripcionCargo(descripcionCargo);

                return StatusCode(HttpStatusCode.Created);
            }
            else
            {
                return BadRequest(ControllerRequestErrorMessages.InvalidRequestInformation);
            }
        }
    }
}
