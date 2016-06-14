using SCAAD.APIs.Data.Implementations;
using SCAAD.APIs.Data.Interfaces;
using SCAAD.APIs.Logic.Business_Rules;
using SCAAD.APIs.Logic.Interfaces;
using SCAAD.APIs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SCAAD.APIs.Logic.Implementations
{ 
    public class PeriodoBusinessRules : ICreateEntityBusinessRules<Periodo>
    {
        public bool CanCreate(Periodo entity)
        {
            if (PeriodoIsInCorrectFormat(entity) && PeriodoIsNotInsideCurrentPeriodo(entity))
                return true;
            else
                return false;
        }

        private bool PeriodoIsInCorrectFormat(Periodo periodo)
        {
            var cicloPeriodo = periodo.Ciclo;
            var formatoSemestreRegex = @"\d{4}-[1-2]"; //2016-1 o 2

            if (Regex.IsMatch(cicloPeriodo, formatoSemestreRegex))
                return true;
            else
                return false;
        }

        private bool PeriodoIsNotInsideCurrentPeriodo(Periodo periodo)
        {
            IPeriodoRepository periodoRepository = new PeriodoRepository();

            var periodoActual = periodoRepository.ReadPeriodoActual();

            if (periodoActual == null)
                return true;

            if (periodo.FechaInicio >= periodoActual.FechaFin)
                return true;
            else
                return false;
        }
    }
}
