using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCAAD.APIs.Models.ViewModels
{
    public class ActividadModificadaViewModel
    {        
        [Required]
        public int Actividad_Id { get; set; }
        [Required]
        public ActividadViewModel Actividad { get; set; }
        [Required]
        [MaxLength(200)]
        public string MotivoModificacion { get; set; }
    }
}
