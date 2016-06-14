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
    [Table("Tbl_PAADActividadModificada")]
    public class PAADActividadModificada
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int PAADActividadOriginal_Id { get; set; }
        public PAADActividad PAADActividadOriginal { get; set; }
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
        [DefaultValue(Common.Constants.ActividadEstatus_NoAcompletado)]
        public int ActividadEstatus_Id { get; set; }
        [ForeignKey("ActividadEstatus_Id")]
        public ActividadEstatus ActividadEstatus { get; set; }
        public string MotivoModificacion { get; set; }
    }
}
