using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SCAAD.APIs.Models.ViewModels
{
    public class ActividadCanceladaViewModel
    {
        [Required]
        public int Actividad_Id { get; set; }
        [Required]
        public string Motivo { get; set; }
    }
}