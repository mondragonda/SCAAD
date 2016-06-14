using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCAAD.APIs.Models.ViewModels
{
    public class PAADViewModel
    {
        [Required]
        public string DocenteId { get; set; }
        [Required]
        public int PeriodoId { get; set; }
        [Required]
        public int DescripcionesCargo_Id { get; set; }
        public int VigenciaSNI_Id { get; set; }
        public DateTime VigenciaPRODEP { get; set; }
        [Required]
        public int HorasLicenciatura { get; set; }
        [Required]
        public int HorasClase { get; set; }
        [Required]
        public int HorasPosgrado { get; set; }
        [Required]
        public int HorasGestion { get; set; }
        [Required]
        public int HorasInvestigacion { get; set; }
        [Required]
        public int HorasTutorias { get; set; }
        [Required]
        public string NombreActividadGestion { get; set; }


    }
}
