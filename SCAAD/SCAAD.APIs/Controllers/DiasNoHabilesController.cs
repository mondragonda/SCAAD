using SCAAD.APIs.Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SCAAD.APIs.Models;


namespace SCAAD.APIs.Controllers
{
#if DEBUG
    [AllowAnonymous]
#else
    [Authorize(Roles = SCAAD.APIs.Common.Constants.Admin)]

#endif
    [RoutePrefix("api/DiasNoHabiles")]
    public class DiasNoHabilesController : CustomBaseController
    {
        private readonly IDiasNoHabilesLogic diasNoHabilesLogic;
        public DiasNoHabilesController(IDiasNoHabilesLogic diasNoHabilesLogic)
        {
            this.diasNoHabilesLogic = diasNoHabilesLogic;
        }

        [HttpGet]
        [Route("")]
        public IHttpActionResult Get()
        {
            var diasNoHabiles = diasNoHabilesLogic.Get();

            if (diasNoHabiles == null || diasNoHabiles.Count == 0)
                return NotFound();
            else
                return Ok(diasNoHabiles);
        }
        //[AllowAnonymous]
        [HttpPost]
        [Route("")]
        public IHttpActionResult Post([FromBody]List<DiasNoHabiles> DiasNoHabiles)
        {
            
            if(DiasNoHabiles==null || !ModelState.IsValid)
            {
                return BadRequest();
            }

            diasNoHabilesLogic.Insert(DiasNoHabiles);

            return Ok();
        }

        [HttpGet]
        [Route("GetDiasNoHabilesPorPeriodoId/{PeriodoId}")]
        public IHttpActionResult GetDiasNoHabilesPorPeriodoId([FromUri]int PeriodoId = 0)
        {

            var dias = diasNoHabilesLogic.GetDiasNoHabilesPorPeriodoId(PeriodoId);
            if (dias.Count == 0)
                return NotFound();

            return Ok(dias);
        }
    }
}
