using SCAAD.APIs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCAAD.APIs.Logic.Interfaces
{
    public interface IDiasNoHabilesLogic
    {
        List<DiasNoHabiles> Get();
        void Insert(List<DiasNoHabiles> DiasNoHabiles);
        List<DiasNoHabiles> GetDiasNoHabilesPorPeriodoId(int PeriodoId);
    }
}
