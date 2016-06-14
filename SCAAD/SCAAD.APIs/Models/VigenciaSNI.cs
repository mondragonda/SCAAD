using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SCAAD.APIs.Models
{
    [Table("Tbl_VigenciasSNI")]
    public class VigenciaSNI
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "Date")]
        public DateTime Fecha { get; set; }
        public int SNI_Id { get; set; }
        [ForeignKey("SNI_Id")]
        public virtual SNI SNI  { get; set; }
        public virtual ICollection<PAAD> PAAD { get; set; }

    }
}