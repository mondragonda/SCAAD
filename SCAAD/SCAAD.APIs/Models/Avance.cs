using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SCAAD.APIs.Models
{
    [Table("Tbl_Avances")]
    public class Avance
    {
        [Key]
        public int Id { get; set; }

        public virtual PAADActividad Actividad { get; set; }
        [Range(0, 100)]
        [DefaultValue(0)]
        public float Porcentaje { get; set; }
        public string Descripcion { get; set; }
        //[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime Creado { get; set; }
        //[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime Modificado { get; set; }



        public virtual ICollection<Evidencia> Evidencias { get; set; }
    }
}