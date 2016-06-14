using AutoMapper;
using SCAAD.APIs.Logic.Business_Rules.Periodo;
using SCAAD.APIs.Logic.Interfaces;
using SCAAD.APIs.Models;
using SCAAD.APIs.Models.ViewModels;
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
    [RoutePrefix("api/Periodos")]
    public class PeriodoController : ApiController
    {
        public PeriodoController(IPeriodoLogic periodoLogic)
        {
            this.periodoLogic = periodoLogic;
        }

        private readonly IPeriodoLogic periodoLogic;

        [HttpGet]
        [Route("")]
        public IHttpActionResult GetPeriodos()
        {
            var periodos = periodoLogic.GetPeriodos();

            if (periodos.Count() == 0)
                return NotFound();

            return Ok(periodos);
        } 

        [Route("PeriodoActual")]
        [HttpGet]
        public IHttpActionResult GetPeriodoActual()
        {
            var periodoActual = periodoLogic.GetPeriodoActual();

            if (periodoActual == null)
                return NotFound();
            else
                return Ok(periodoActual);
        }

        [Route("RegistrarPeriodo")]
        [HttpPost]
        public IHttpActionResult Post(PeriodoViewModel periodo)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var periodoModel = Mapper.Map<Periodo>(periodo);
                    periodoLogic.AddPeriodo(periodoModel);

                    return Ok(PeriodoSucceedMessages.RegistroPeriodoExitoso);

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
        [HttpPut]
        [Route("ModificarPeriodo")]
        public IHttpActionResult Put(PeriodoViewModel periodo)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var periodoModel = Mapper.Map<Periodo>(periodo);
                    periodoLogic.ModificarPeriodo(periodoModel);

                    return Ok(PeriodoSucceedMessages.RegistroPeriodoExitoso);

                }
                catch (InvalidOperationException e)
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
