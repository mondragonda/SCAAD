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
    [Table("Tbl_JustificacionesPAAD")]
    public class JustificacionPAAD
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int PAAD_Id { get; set; }
        [ForeignKey("PAAD_Id")]
        public virtual PAAD PAAD { get; set; }
        [Required]
        public int TipoCambio_Id { get; set; }
        [ForeignKey("TipoCambio_Id")]
        public virtual TiposCambio TiposCambio { get; set; }
        [Required]
        [MaxLength(100)]
        public string Descripcion { get; set; }
        [Required]
        [DefaultValue(false)]
        public bool Aprobado { get; set; }
    }
}
