using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SCAAD.APIs.Models.ViewModels
{
    public class ActividadCompletadaViewModel
    {
        [Required]
        public int Actividad_Id { get; set; }
        [Required]
        [Range(0, 100)]
        public int Porcentaje { get; set; }
    }
}