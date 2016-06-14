using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCAAD.APIs.Models
{
    [Table("Tbl_ActividadCancelada")]
    public class ActividadCancelada
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int Actividad_Id { get; set; }
        [ForeignKey("Actividad_Id")]
        public virtual Actividad Actividad { get; set; }
        [Required]
        public string Motivo { get; set; }

    }
}
