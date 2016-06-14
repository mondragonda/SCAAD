using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SCAAD.APIs.Models.ViewModels
{
    public class CambiarPasswordViewModel
    {
        [Required]
        public string UsuarioId { get; set; }
        [Required]
        public string Password { get; set; }
    }
}