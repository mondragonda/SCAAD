using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SCAAD.APIs.Models
{
    [Table("Tbl_ActividadEstatus")]

    public class ActividadEstatus
    {
        [Key]
        public int Id { get; set; }
        public string Descripcion { get; set; }
    }
}