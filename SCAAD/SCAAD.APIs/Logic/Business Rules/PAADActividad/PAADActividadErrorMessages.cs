using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCAAD.APIs.Logic.Business_Rules.PAADActividad
{
    public static class PAADActividadErrorMessages
    {
        public static string InvalidRegister
        {
            get
            {
                return "El registro de la actividad del PAAD no fue permitido por el sistema."
                      + " La actividad ya existe en el sistema o las fechas de inicio y/o finalización están"
                      +" fuera del periodo actual";
            }
        }
    }
}
