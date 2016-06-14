using SCAAD.APIs.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SCAAD.APIs.Models;

namespace SCAAD.APIs.Data.Implementations
{
    public class CargoRepository : UpdatableRepositoryBase<Cargo>, ICargoRepository
    {
        public void InsertCargo(Cargo cargo)
        {
            base.Insert(cargo);
        }

        public IEnumerable<Cargo> ReadCargos()
        {
            var cargos = base.Get();

            return cargos;
        }
    }
}
