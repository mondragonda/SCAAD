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
    public class TiempoCargoLogic : ITiempoCargoLogic
    {
        public TiempoCargoLogic(ITiempoCargoRepository tiempoCargoRepository)
        {
            this.tiempoCargoRepository = tiempoCargoRepository;
        }
        private readonly ITiempoCargoRepository tiempoCargoRepository;
        public void AddTiempoCargo(TiempoCargo tiempoCargo)
        {
            tiempoCargoRepository.InsertTiempoCargo(tiempoCargo);
        }

        public IEnumerable<TiempoCargo> GetTiemposCargo()
        {
            var tiemposCargo = tiempoCargoRepository.ReadTiemposCargo();

            return tiemposCargo;
        }
    }
}
