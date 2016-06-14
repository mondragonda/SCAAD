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
    [RoutePrefix("api/Cargos")]
    public class CargoController : ApiController
    {
        public CargoController(ICargoLogic cargoLogic)
        {
            this.cargoLogic = cargoLogic;
        }
        private readonly ICargoLogic cargoLogic;
  
        public IHttpActionResult Get()
        {
            var cargos = cargoLogic.GetCargos();

            if (cargos.Count() == 0)
                return NotFound();
            else
                return Ok(cargos);
        }
        [Route("RegistrarCargo")]
        public IHttpActionResult Post(Cargo cargo)
        {
            if (ModelState.IsValid)
            {
                cargoLogic.AddCargo(cargo);

                return StatusCode(HttpStatusCode.Created);
            }
            else
            {
                return BadRequest(ControllerRequestErrorMessages.InvalidRequestInformation);
            }

        }
    }
}
