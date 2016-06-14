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
    public class OpcionesCargoLogic : IOpcionesCargoLogic
    {
        public OpcionesCargoLogic(IOpcionesCargoRepository opcionesCargoRepository)
        {
            this.opcionesCargoRepository = opcionesCargoRepository;
        }

        private readonly IOpcionesCargoRepository opcionesCargoRepository;
        public void AddOpcionCargo(OpcionesCargo opcionCargo)
        {
            opcionesCargoRepository.InsertOpcionCargo(opcionCargo);
        }

        public IEnumerable<OpcionesCargo> GetOpcionesCargos()
        {
           var opcionesCargo = opcionesCargoRepository.ReadOpcionesCargo();

            return opcionesCargo;
        }
    }
}
