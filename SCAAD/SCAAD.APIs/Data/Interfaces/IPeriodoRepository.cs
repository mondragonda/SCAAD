using SCAAD.APIs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCAAD.APIs.Data.Interfaces
{
    public interface IPeriodoRepository :IUpdatable<Periodo>, ICollectionReadable<Periodo>
    {
        void InsertPeriodo(Periodo periodo);
        Periodo ReadPeriodoActual();

        IEnumerable<Periodo> ReadPeriodos();
        Periodo GetPeriodoConDiasNoHabiles(int id);
    }
}
