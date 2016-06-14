using AutoMapper;
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
    [RoutePrefix("api/CategoriaActividad")]
    public class CategoriaActividadController : ApiController
    {
        public CategoriaActividadController(ICategoriaLogic categoriaLogic)
        {
            this.categoriaLogic = categoriaLogic;
        }

        private readonly ICategoriaLogic categoriaLogic;

        public IHttpActionResult Get()
        {
            var categorias = categoriaLogic.GetCategorias();

            if (categorias.Count() == 0)
                return NotFound();

            return Ok(categorias);
        }
        [Route("AgregarCategoria")]
        public IHttpActionResult Post(CategoriaViewModel categoriaViewModel)
        {
            if (ModelState.IsValid)
            {
                var categoria = Mapper.Map<Categoria>(categoriaViewModel);

                categoriaLogic.AddCategoria(categoria);

                return StatusCode(HttpStatusCode.Created);
            }

            return BadRequest(ControllerRequestErrorMessages.InvalidRequestInformation);
        }
    }
}
