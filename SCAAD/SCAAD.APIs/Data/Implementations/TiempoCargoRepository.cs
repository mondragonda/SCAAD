using SCAAD.APIs.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SCAAD.APIs.Models;

namespace SCAAD.APIs.Data.Implementations
{
    public class TiempoCargoRepository : UpdatableRepositoryBase<TiempoCargo>, ITiempoCargoRepository
    {
        public void InsertTiempoCargo(TiempoCargo tiempoCargo)
        {
            base.Insert(tiempoCargo);
        }

        public IEnumerable<TiempoCargo> ReadTiemposCargo()
        {
            var tiemposCargo = base.Get();

            return tiemposCargo;
        }
    }
}
