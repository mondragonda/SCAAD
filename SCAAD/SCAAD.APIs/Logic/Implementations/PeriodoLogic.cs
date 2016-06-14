using SCAAD.APIs.Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SCAAD.APIs.Models;
using SCAAD.APIs.Data.Interfaces;
using SCAAD.APIs.Logic.Business_Rules;
using SCAAD.APIs.Logic.Business_Rules.Periodo;
using System.Text.RegularExpressions;

namespace SCAAD.APIs.Logic.Implementations
{
    public class PeriodoLogic : IPeriodoLogic
    {
        public PeriodoLogic(IPeriodoRepository periodoRepository, ICreateEntityBusinessRules<Periodo> createPeriodoBusinessRules)
        {
            this.periodoRepository = periodoRepository;
            this.createPeriodoBusinessRules = createPeriodoBusinessRules;
        }

        private readonly IPeriodoRepository periodoRepository;
        private readonly ICreateEntityBusinessRules<Periodo> createPeriodoBusinessRules;

        public void AddPeriodo(Periodo periodo)
        {
            if (createPeriodoBusinessRules.CanCreate(periodo))
                periodoRepository.InsertPeriodo(periodo);
            else
                throw new InvalidOperationException(PeriodoErrorMessages.InvalidPeriodo);
        }

        public Periodo GetPeriodoActual()
        {
            var periodoActual = periodoRepository.ReadPeriodoActual();

            return periodoActual;
        }

        public IEnumerable<Periodo> GetPeriodos()
        {
            return periodoRepository.ReadPeriodos();
        }

        public void ModificarPeriodo(Periodo periodoModel)
        {
            if(CicloDelPeriodoTieneFormatoCorrecto(periodoModel) 
                && PeriodoTieneDiasNoHabilesAsignados(periodoModel))
            periodoRepository.Update(periodoModel, r => r.Ciclo, r => r.FechaInicio, r => r.FechaFin);
            else
                throw new InvalidOperationException(PeriodoErrorMessages.InvalidPeriodo);

        }


        private bool CicloDelPeriodoTieneFormatoCorrecto(Periodo periodo)
        {
            var cicloPeriodo = periodo.Ciclo;
            var formatoSemestreRegex = @"\d{4}-[1-2]"; //2016-1 o 2

            if (Regex.IsMatch(cicloPeriodo, formatoSemestreRegex))
                return true;
            else
                return false;
        }

        private bool PeriodoTieneDiasNoHabilesAsignados(Periodo periodo)
        {
            Periodo result = periodoRepository.GetPeriodoConDiasNoHabiles(periodo.Id);
            return result.DiasNoHabiles.Count == 0 ? true : false;
        }
    }
}
