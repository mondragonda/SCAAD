using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SCAAD.APIs.Models
{
    [Table("Tbl_Docentes")]
    public class Docente 
    {
        [Key]
        public string Id { get; set; }
        [Required]
        public int NumeroEmplado { get; set; }
        [Required]
        [MaxLength(100)]
        public string Nombre { get; set; }
        [Required]
        [MaxLength(100)]
        public string Apellido { get; set; }
        public int Carrera_Id { get; set; }
        [ForeignKey("Carrera_Id")]
        public virtual Carrera Carrera { get; set; }
        public virtual ICollection<PAAD> PAADs { get; set; }
        public bool InformacionActualizada { get; set; }
        public string idUsuario { get; set; }
        [NotMapped]
        public string NombreCompleto { get { return Nombre + " " +Apellido; } }
    }
}