using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCAAD.APIs.Models.ViewModels
{
    public class DocenteViewModel
    {
        [Required]
        public string userId { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Apellido { get; set; }
        [Required]
        public int NumeroEmplado { get; set; }
        [Required]
        public int CarreraId { get; set; }
    }
}
