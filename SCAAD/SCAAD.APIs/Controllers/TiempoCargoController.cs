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
    [RoutePrefix("api/TiemposCargo")]
    public class TiempoCargoController : ApiController
    {
        public TiempoCargoController(ITiempoCargoLogic tiempoCargoLogic)
        {
            this.tiempoCargoLogic = tiempoCargoLogic;
        }

        private readonly ITiempoCargoLogic tiempoCargoLogic;

        [Route("")]
        public IHttpActionResult Get()
        {
            var tiemposCargo = tiempoCargoLogic.GetTiemposCargo();

            if (tiemposCargo.Count() == 0)
                return NotFound();
            else
                return Ok(tiemposCargo);
        }

        [Route("RegistrarTiempoCargo")]
        public IHttpActionResult Post(TiempoCargo tiempoCargo)
        {
            if(ModelState.IsValid)
            {
                tiempoCargoLogic.AddTiempoCargo(tiempoCargo);

                return StatusCode(HttpStatusCode.Created);
            }
            else
            {
                return BadRequest(ControllerRequestErrorMessages.InvalidRequestInformation);
            }

        }
    }
}
