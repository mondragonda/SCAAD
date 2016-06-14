using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SCAAD.APIs.Models
{
    [Table("Tbl_DescripcionesCargo")]
    public class DescripcionCargo
    {
        [Key]
        public int Id { get; set; }
        public int Cargo_Id { get; set; }
        [ForeignKey("Cargo_Id")]
        public virtual Cargo Cargo { get; set; }
        public int Rango_Id { get; set; }
        [ForeignKey("Rango_Id")]
        public virtual Rango Rangos { get; set; }
        public int TiempoCargo_Id { get; set; }
        [ForeignKey("TiempoCargo_Id")]
        public virtual TiempoCargo TiempoCargo { get; set; }
        public int TipoCargo_Id { get; set; }
        [ForeignKey("TipoCargo_Id")]
        public virtual TiposCargo TipoCargo { get; set; }
        public int OpcionesCargo_Id { get; set; }
        [ForeignKey("OpcionesCargo_Id")]
        public virtual OpcionesCargo OpcionesCargo { get; set; }

        public virtual ICollection<PAAD> PAADs { get; set; }
    }
}