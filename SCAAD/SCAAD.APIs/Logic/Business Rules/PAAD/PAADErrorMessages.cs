using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SCAAD.APIs.Common
{
    public static class PAADErrorMessages
    {
        public static string InvalidRegister
        {
            get
            {
                return "El registro del PAAD no fue permitido por el sistema."
                       + " Ya existe un PAAD Registrado en el periodo actual y/o"
                       + " la suma de las horas de la cabecera excede el máximo de 40 horas y/o"
                       + " el periodo de registro de PAAD ya fue cerrado";
            }
        }

        public static string ModificationNotAllowed
        {
            get
            {
                return "La modificación del PAAD no fue permitida por el sistema";
            }
        }
    }
}