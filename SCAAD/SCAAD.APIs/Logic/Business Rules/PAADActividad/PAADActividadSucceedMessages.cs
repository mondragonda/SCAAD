using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCAAD.APIs.Logic.Business_Rules.PAADActividad
{
    public static class PAADActividadSucceedMessages
    {
        public static string RegistroPAADActividadExitoso
        {
            get
            {
                return "La actividad del PAAD se ha registrado correctamente";
            }
        }

        public static string ModificacionPAADActividadExitosa
        {
            get
            {
                return "La actividad del PAAD se ha modificado correctamente";
            }
        }

        public static string CancelacionActividadExitosa
        {
            get
            {
                return "La actividad del PAAD se ha cancelada correctamente";
            }
        }

    }
}
