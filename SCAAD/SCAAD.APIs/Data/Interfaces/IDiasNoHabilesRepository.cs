using SCAAD.APIs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCAAD.APIs.Data.Interfaces
{
    public interface IDiasNoHabilesRepository : IUpdatable<DiasNoHabiles>, ICollectionReadable<DiasNoHabiles>
    {
        List<DiasNoHabiles> GetDiasNoHabilesPeriodoActual(DateTime FechaInicio, DateTime FechaFinal);
        void InsertListDiasNohabiles(List<DiasNoHabiles> NuevosDiasNoHabiles);
        List<DiasNoHabiles> GetDiasNoHabilesPorPeriodoId(int periodoId);
    }
}
