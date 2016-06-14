using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SCAAD.APIs.Models
{
    [Table("Tbl_Evidencias")]
    public class Evidencia
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int PAADActividad_Id { get; set; }
        [ForeignKey("PAADActividad_Id")]
        public virtual PAADActividad PAADActividad { get; set; }       
        public string Descripcion { get; set; }
        [Required]
        public string RutaDocumento { get; set; }
        [Required]
        [Column(TypeName = "Date")]
        public DateTime FechaAgregado { get; set; }
        [Required]
        [DefaultValue(0.0f)]
        public float PorcentajeEvaluacion { get; set; }
    }
}