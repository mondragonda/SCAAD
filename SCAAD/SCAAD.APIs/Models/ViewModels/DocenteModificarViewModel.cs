using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SCAAD.APIs.Models.ViewModels
{
    public class DocenteModificarViewModel
    {
        public string UserId { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Apellido { get; set; }
        [Required]
        public int Carrera_Id { get; set; }
        [Required]
        public string Password { get; set; }

    }
}