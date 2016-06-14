using SCAAD.APIs.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SCAAD.APIs.Models;

namespace SCAAD.APIs.Data.Implementations
{
    public class TiposCargoRepository : UpdatableRepositoryBase<TiposCargo>, ITiposCargoRepository
    {
        public void InsertTipoCargo(TiposCargo tipoCargo)
        {
            base.Insert(tipoCargo);
        }

        public IEnumerable<TiposCargo> ReadTiposCargo()
        {
            var tiposCargo = base.Get();

            return tiposCargo;
        }
    }
}
