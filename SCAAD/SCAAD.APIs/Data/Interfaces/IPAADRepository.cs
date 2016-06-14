using SCAAD.APIs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SCAAD.APIs.Data.Interfaces
{
    public interface IPAADRepository: IUpdatable<PAAD>
    {
        void CreatePAAD(PAAD PAAD);
        IEnumerable<PAAD> ReadPAADs();
        IEnumerable<PAAD> ReadPAADs(Expression<Func<PAAD, bool>> expresion);
        PAAD ReadPAADs(string docenteId, Periodo periodoActual);
        void UpdatePAAD(PAAD PAAD);
        void DeletePAAD(PAAD PAAD);
    }
}
