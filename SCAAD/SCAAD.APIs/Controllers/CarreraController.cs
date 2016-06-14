using SCAAD.APIs.Logic.Interfaces;
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
    [Authorize(Roles = SCAAD.APIs.Common.Constants.Docente)]

#endif
    [RoutePrefix("api/Carrera")]
    public class CarreraController :  CustomBaseController
    {
        private readonly ICarreraLogic carreraLogic;

        public CarreraController(ICarreraLogic carreraLogic)
        {
            this.carreraLogic = carreraLogic;
        }

        [HttpGet]
        [Route("")]
        public IHttpActionResult Get()
        {

            return Ok(carreraLogic.GetAll());
        }
    }
}
