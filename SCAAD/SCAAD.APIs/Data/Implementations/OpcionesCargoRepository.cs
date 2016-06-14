using SCAAD.APIs.Data.Interfaces;
using SCAAD.APIs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCAAD.APIs.Data.Implementations
{
    public class OpcionesCargoRepository : UpdatableRepositoryBase<OpcionesCargo>, IOpcionesCargoRepository
    {
        public void InsertOpcionCargo(OpcionesCargo opcionCargo)
        {
            base.Insert(opcionCargo);
        }

        public IEnumerable<OpcionesCargo> ReadOpcionesCargo()
        {
            var opcionesCargo = base.Get();

            return opcionesCargo;
        }
    }
}
