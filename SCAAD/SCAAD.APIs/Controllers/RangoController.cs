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
    [RoutePrefix("api/Rangos")]
    public class RangoController : ApiController
    {
        public RangoController(IRangoLogic rangoLogic)
        {
            this.rangoLogic = rangoLogic;
        }

        private readonly IRangoLogic rangoLogic;

        [Route("")]
        public IHttpActionResult Get()
        {
            var rangos = rangoLogic.GetRangos();

            if (rangos.Count() == 0)
                return NotFound();
            else
                return Ok(rangos);
        }

        [Route("RegistrarRango")]
        public IHttpActionResult Post(Rango rango)
        {
            if (ModelState.IsValid)
            {
                rangoLogic.AddRango(rango);

                return StatusCode(HttpStatusCode.Created);
            }
            else
            {
                return BadRequest(ControllerRequestErrorMessages.InvalidRequestInformation);
            }

        }
    }
}
