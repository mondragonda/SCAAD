using SCAAD.APIs.Logic.Interfaces;
using SCAAD.APIs.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;

namespace SCAAD.APIs.Controllers
{
    [AllowAnonymous]
    [RoutePrefix("api/Evidencia")]
    public class EvidenciaController : CustomBaseController
    {
        private readonly IEvidenciaLogic evidenciaLogic;
        public EvidenciaController(IEvidenciaLogic evidenciaLogic)
        {
            this.evidenciaLogic = evidenciaLogic;
        }

        [Route("AgregarEvidencia/{Actividad_Id}")]
        [HttpPost]
        public IHttpActionResult AgregarEvidencia([FromUri]int Actividad_Id,[FromBody]EvidenciasViewModel model)
        {
            model.Actividad_Id = Actividad_Id;
            if (ModelState.IsValid)
            {
                evidenciaLogic.AgregarEvidenciaPorActividadId(model);
                return Ok();
            }
            return BadRequest();      
           
        }




        [HttpGet]
        [Route("BajarEvidencia/{Evidencia_Id}")]
        public HttpResponseMessage BajarEvidencia(int Evidencia_Id)
        {
            var resultPath = evidenciaLogic.GetEvidenciaById(Evidencia_Id);
            if (resultPath == null)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
            var path = System.Web.HttpContext.Current.Server.MapPath(string.Format("~/Uploads/{0}", resultPath)); 
            //var path = System.Web.HttpContext.Current.Server.MapPath(resultPath);
            HttpResponseMessage result = new HttpResponseMessage(HttpStatusCode.OK);
            var stream = new FileStream(path, FileMode.Open);
            result.Content = new StreamContent(stream);
            result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment");
            result.Content.Headers.ContentDisposition.FileName = Path.GetFileName(path);
            result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
            result.Content.Headers.ContentLength = stream.Length;
            return result;
        }
    }
}
