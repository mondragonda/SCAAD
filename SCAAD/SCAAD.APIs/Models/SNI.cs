using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SCAAD.APIs.Models
{
    [Table("Tbl_SNIs")]
    public class SNI
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(15)]
        public string Nivel { get; set; }

        public virtual ICollection<VigenciaSNI> VigenciasSNIs { get; set; }


    }
}