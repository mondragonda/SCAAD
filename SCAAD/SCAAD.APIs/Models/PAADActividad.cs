using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SCAAD.APIs.Models
{
    [Table("Tbl_PAADActividades")]
    public class PAADActividad
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int PAAD_Id { get; set; }
        [ForeignKey("PAAD_Id")]
        public virtual PAAD PAAD { get; set; }
        [Required]
        public int Categoria_id { get; set; }
        [ForeignKey("Categoria_id")]
        public virtual Categoria Categoria { get; set; }
        [Required]
        [Column(TypeName = "Date")]
        public DateTime Inicio { get; set; }
        [Required]
        [Column(TypeName = "Date")]
        public DateTime Finalizacion { get; set; }
        [Required]
        [MaxLength(50)]
        public string Produccion { get; set; }
        [Required]
        [DefaultValue(false)]
        public bool CACEI_CIEES { get; set; }
        [Required]
        [DefaultValue(false)]
        public bool CuerpoAcademico { get; set; }
        [Required]
        [DefaultValue(0)]
        public int PorcentajeAvance { get; set; }
        [DefaultValue(Common.Constants.ActividadEstatus_NoAcompletado)]
        public int ActividadEstatus_Id { get; set; }
        [ForeignKey("ActividadEstatus_Id")]
        public ActividadEstatus ActividadEstatus { get; set; }
        [DefaultValue(false)]
        public bool Completada { get; set; }
        [DefaultValue(false)]
        public bool Cancelada { get; set; }
        public virtual ICollection<Evidencia> Evidencias { get; set; }
        public virtual ICollection<JustificacionPAADActividades> Justificaciones { get; set; }


    }
}