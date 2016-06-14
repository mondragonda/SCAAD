using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SCAAD.APIs.Models
{
    [Table("Tbl_Periodos")]
    public class Periodo
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Ciclo { get; set; }
        [Required]
        [Column(TypeName = "Date")]
        public DateTime FechaInicio { get; set; }
        [Required]
        [Column(TypeName = "Date")]
        public DateTime FechaFin{ get; set; }


        public virtual List<DiasNoHabiles> DiasNoHabiles { get; set; }
        public virtual ICollection<PAAD> PAADs { get; set; }

    }
}