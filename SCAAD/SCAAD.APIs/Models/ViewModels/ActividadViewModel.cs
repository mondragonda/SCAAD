using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SCAAD.APIs.Models.ViewModels
{
    public class ActividadViewModel
    {
        [Required]
        public int idCategoria { get; set; }
        [Required]
        public DateTime FechaInicio { get; set; }
        [Required]
        public DateTime FechaFinalizacion { get; set; }
        [Required]
        public string Produccion { get; set; }
        [Required]
        [DefaultValue(false)]
        public bool CACEI_CIEES { get; set; }
        [Required]
        [DefaultValue(false)]
        public bool CuerpoAcademico { get; set; }
        //[Required]
        //[DefaultValue(0)]
        //public float Porcentaje { get; set; }
        //[Required]
        //[DefaultValue(false)]
        //public bool Completada { get; set; }
    }
}