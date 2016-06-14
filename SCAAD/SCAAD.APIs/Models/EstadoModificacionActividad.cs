using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCAAD.APIs.Models
{
    [Table("Tbl_EstadoModificacionActividad")]
    public class EstadoModificacionActividad
    {
        [Key]
        public int Id { get; set; }
        public string Estado { get; set; }
        public string Description { get; set; }
    }
}