using SCAAD.APIs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SCAAD.APIs.Data.Interfaces
{
    public interface IPAADActividadRepository : IUpdatable<PAADActividad>
    {
        void CreateActividad(PAADActividad PAADActividad);
        IEnumerable<PAADActividad> ReadActividades(Expression<Func<PAADActividad, bool>> expresion);
        void UpdateActividad(int idPAADActividad, PAADActividad PAADActividad);

    }
}
