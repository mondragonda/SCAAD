using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SCAAD.APIs.Models
{
    [Table("Tbl_Rangos")]
    public class Rango
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(20)]
        public string Nombre { get; set; }

        public virtual ICollection<DescripcionCargo> DescripcionesCargo { get; set; }
    }
}