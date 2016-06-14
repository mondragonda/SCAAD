using SCAAD.APIs.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SCAAD.APIs.Models;

namespace SCAAD.APIs.Data.Implementations
{
    public class RangoRepository : UpdatableRepositoryBase<Rango>, IRangoRepository
    {
        public void InsertRango(Rango rango)
        {
            base.Insert(rango);
        }

        public IEnumerable<Rango> ReadRangos()
        {
            var rangos = base.Get();

            return rangos;
        }
    }
}
