using SCAAD.APIs.Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SCAAD.APIs.Models;
using SCAAD.APIs.Data.Interfaces;

namespace SCAAD.APIs.Logic.Implementations
{
    public class CargoLogic : ICargoLogic
    {
        public CargoLogic(ICargoRepository cargoRepository)
        {
            this.cargoRepository = cargoRepository;
        }
        private readonly ICargoRepository cargoRepository;
        public void AddCargo(Cargo cargo)
        {
            cargoRepository.InsertCargo(cargo);
        }

        public IEnumerable<Cargo> GetCargos()
        {
            return cargoRepository.ReadCargos();
        }
    }
}
