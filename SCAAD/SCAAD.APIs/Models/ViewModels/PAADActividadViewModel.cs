using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCAAD.APIs.Models.ViewModels
{
    public class PAADActividadViewModel
    {
        [Required]
        public int idPAAD { get; set; }
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
