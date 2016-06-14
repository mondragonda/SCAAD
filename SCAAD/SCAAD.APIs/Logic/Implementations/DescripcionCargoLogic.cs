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
    public class DescripcionCargoLogic : IDescripcionCargoLogic
    {
        public DescripcionCargoLogic(IDescripcionCargoRepository descripcionCargoRepository)
        {
            this.descripcionCargoRepository = descripcionCargoRepository;
        }

        private readonly IDescripcionCargoRepository descripcionCargoRepository;
        public void AddDescripcionCargo(DescripcionCargo descripcionCargo)
        {
            descripcionCargoRepository.InsertDescripcionCargo(descripcionCargo);
        }

        public IEnumerable<DescripcionCargo> GetDescripcionesCargo()
        {
            var descripcionesCargo = descripcionCargoRepository.ReadDescripcionesCargo();

            return descripcionesCargo;
        }
    }
}
