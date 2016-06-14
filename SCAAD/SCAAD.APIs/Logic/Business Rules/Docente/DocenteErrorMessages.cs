using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCAAD.APIs.Logic.Business_Rules.Docente
{
    public static class DocenteErrorMessages
    {
        public static string DocenteAlreadyExists
        {
            get
            {
                return "El número de empleado del docente o su id de usuario ya está registrado en el sistema";
            }
        }
    }
}
