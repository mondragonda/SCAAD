using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SCAAD.APIs.Models
{
    public class GestionHoras
    {
        public int GestionHorasID { get; set; }
        public int HorasClase { get; set; }
        public int HorasPosgrado { get; set; }
        public int HorasGestion { get; set; }
        public int HorasInvestigacion { get; set; }
        public int HorasTutorias { get; set; }

        // Navigation property 
        public virtual ICollection<Docente> Docentes { set; get; }

    }
}