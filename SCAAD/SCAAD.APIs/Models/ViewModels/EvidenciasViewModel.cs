using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SCAAD.APIs.Models.ViewModels
{
    public class EvidenciasViewModel
    {
        public int Actividad_Id { get; set; }
        [Required]
        public string DescripcionArchivo { get; set; }
        [Required]
        public string File { get; set; }
        [Required]
        public float Porcentaje { get; set; }
    }
}