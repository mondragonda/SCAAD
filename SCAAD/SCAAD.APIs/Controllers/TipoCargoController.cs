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
    [RoutePrefix("api/TiposCargo")]
    public class TipoCargoController : ApiController
    {
        public TipoCargoController(ITiposCargoLogic tiposCargoLogic)
        {
            this.tiposCargoLogic = tiposCargoLogic;
        }

        private readonly ITiposCargoLogic tiposCargoLogic;
        
        [Route("")]
        public IHttpActionResult Get()
        {
            var tiposCargo = tiposCargoLogic.GetTiposCargo();

            if (tiposCargo.Count() == 0)
                return NotFound();
            else
                return Ok(tiposCargo);
        }

        [Route("RegistrarTipoCargo")]
        public IHttpActionResult Post(TiposCargo tipoCargo)
        {
            if (ModelState.IsValid)
            {
                tiposCargoLogic.AddTipoCargo(tipoCargo);

                return StatusCode(HttpStatusCode.Created);
            }
            else
            {
                return BadRequest(ControllerRequestErrorMessages.InvalidRequestInformation);
            }
        }
    }
}
