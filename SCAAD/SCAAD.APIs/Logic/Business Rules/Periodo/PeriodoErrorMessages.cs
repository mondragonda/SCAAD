using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCAAD.APIs.Logic.Business_Rules.Periodo
{
    public static class PeriodoErrorMessages
    {
        public static string InvalidPeriodo
        {
            get
            {
                return "El formato del ciclo escolar del periodo es inválido  " +
                       "o las fechas del periodo se encuentran dentro del periodo actual";
            }
        }
    }
}
