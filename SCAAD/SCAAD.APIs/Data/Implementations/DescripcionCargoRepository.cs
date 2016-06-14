using SCAAD.APIs.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SCAAD.APIs.Models;

namespace SCAAD.APIs.Data.Implementations
{
    public class DescripcionCargoRepository : UpdatableRepositoryBase<DescripcionCargo>, IDescripcionCargoRepository
    {
        public void InsertDescripcionCargo(DescripcionCargo descripcionCargo)
        {
            base.Insert(descripcionCargo);
        }

        public IEnumerable<DescripcionCargo> ReadDescripcionesCargo()
        {
            var descripcionesCargo = base.Get("Cargo");

            return descripcionesCargo;
        }
    }
}
