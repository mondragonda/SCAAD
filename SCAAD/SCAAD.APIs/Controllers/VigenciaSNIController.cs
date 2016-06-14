using SCAAD.APIs.Logic.Business_Rules.VigenciaSNI;
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
    [Authorize(Roles = SCAAD.APIs.Common.Constants.Docente)]
#endif
    [RoutePrefix("api/VigenciasSNI")]
    public class VigenciaSNIController : ApiController
    {
        public VigenciaSNIController(IVigenciaSNILogic vigenciaSNILogic)
        {
            this.vigenciaSNILogic = vigenciaSNILogic;
        }

        private readonly IVigenciaSNILogic vigenciaSNILogic;

        [Route("")]
        public IHttpActionResult Get()
        {
            var vigenciasSNI = vigenciaSNILogic.GetVigenciasSNI();

            if (vigenciasSNI.Count() == 0)
                return NotFound();
            else
                return Ok(vigenciasSNI);
        }

        [Route("RegistrarVigenciaSNI")]
        public IHttpActionResult Post(VigenciaSNI vigenciaSNI)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    vigenciaSNILogic.AddVigenciaSNI(vigenciaSNI);

                    return Ok(VigenciaSNISuceedMessages.RegistroSNIExitoso);

                }catch(InvalidOperationException e)
                {
                    return BadRequest(e.Message);
                }
            }
            else
            {
                return BadRequest(ControllerRequestErrorMessages.InvalidRequestInformation);
            }
        }


    }
}
