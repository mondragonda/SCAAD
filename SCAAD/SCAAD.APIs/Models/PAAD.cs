using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SCAAD.APIs.Models
{
    [Table("Tbl_PAADs")]
    public class PAAD
    {
        [Key]
        public int Id { get; set; }
        public string Docente_Id { get; set; }
        [ForeignKey("Docente_Id")]
        public virtual Docente Docente { get; set; }
        public int Periodo_Id { get; set; }
        [ForeignKey("Periodo_Id")]
        public virtual Periodo Periodo { get; set; }
        public int DescripcionesCargo_Id { get; set; }
        [ForeignKey("DescripcionesCargo_Id")]
        public virtual DescripcionCargo DescripcionesCargo { get; set; }
        public int VigenciaSNI_Id { get; set; }
        [ForeignKey("VigenciaSNI_Id")]
        public virtual VigenciaSNI VigenciasSNI { get; set; }
        [Column(TypeName = "Date")]
        public DateTime? VigenciaPRODEP { get; set; }
        [Required]
        [DefaultValue(0)]
        public int HorasLicenciaturas { get; set; }
        [Required]
        [DefaultValue(0)]
        public int HorasClase { get; set; }
        [Required]
        [DefaultValue(0)]
        public int HorasPosgrado { get; set; }
        [Required]
        [DefaultValue(0)]
        public int HorasGestion { get; set; }
        [Required]
        [DefaultValue(0)]
        public int HorasInvestigacion { get; set; }
        [Required]
        [DefaultValue(0)]
        public int HorasTutorias { get; set; }
        [DefaultValue(SCAAD.APIs.Common.Constants.PAADEstatus_Rechazado)]
        public int PAADEstatus_Id { get; set; }
        [ForeignKey("PAADEstatus_Id")]
        public PAADEstatus PAADEstatus { get; set; }
        [Required]
        public string NombreActividadGestion { get; set; }
        public bool Completado { get; set; }
        public virtual ICollection<PAADActividad> PAADActividades { get; set; }
        public virtual ICollection<JustificacionPAAD> Justificaciones { get; set; }


    }
}