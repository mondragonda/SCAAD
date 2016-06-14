using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCAAD.APIs.Models
{
    [Table("Tbl_PAADModificado")]
    public class PAADModificado
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int PAADOriginal_Id { get; set; }
        [ForeignKey("PAADOriginal_Id")]
        public virtual PAAD PAADOriginal { get; set; }
        [Required]
        public string Docente_Id { get; set; }
        [ForeignKey("Docente_Id")]
        public virtual Docente Docente { get; set; }
        [Required]
        public int Periodo_Id { get; set; }
        [ForeignKey("Periodo_Id")]
        public virtual Periodo Periodo { get; set; }
        [Required]
        public int DescripcionCargo_Id { get; set; }
        [ForeignKey("DescripcionCargo_Id")]
        public DescripcionCargo DescripcionesCargo { get; set; }
        [Required]
        public int VigenciaSNI_Id { get; set; }
        [ForeignKey("VigenciaSNI_Id")]
        public virtual VigenciaSNI VigenciasSNI { get; set; }
        [Required]
        public DateTime? VigenciaPRODEP { get; set; }
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
        public int PAADEstatus_Id { get; set; }
        [ForeignKey("PAADEstatus_Id")]
        public virtual PAADEstatus PAADEstatus { get; set; }
        [Required]
        public string NombreActividadGestion { get; set; }
        [Required]
        public string MotivoModificacion { get; set; }

    }
}
