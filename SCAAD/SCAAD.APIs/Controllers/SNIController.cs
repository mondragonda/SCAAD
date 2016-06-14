using SCAAD.APIs.Logic.Interfaces;
using SCAAD.APIs.Models;
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
    [RoutePrefix("api/SNI")]
    public class SNIController : CustomBaseController
    {
        private readonly ISNILogic sniLogic;

        public SNIController(ISNILogic sniLogic)
        {
            this.sniLogic = sniLogic;
        }

        [HttpGet]
        [Route("")]
        public IHttpActionResult Get()
        {

            return Ok(sniLogic.GetAll());
        }


        [HttpPost]
        [Route("RegistarSNI")]
        public IHttpActionResult Insert(SNI sni)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            sniLogic.Insert(sni);

            return Ok();
        }
    }
}
