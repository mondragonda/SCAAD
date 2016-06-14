using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SCAAD.APIs.Models
{
    [Table("Tbl_DiasNoHabiles")]
    public class DiasNoHabiles
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "Date")]
        public DateTime Fecha { get; set; }
        [MaxLength(50)]
        public string Motivo { get; set; }

        public int Periodo_Id { get; set; }
        [ForeignKey("Periodo_Id")]
        public Periodo Periodo { get; set; }
    }
}