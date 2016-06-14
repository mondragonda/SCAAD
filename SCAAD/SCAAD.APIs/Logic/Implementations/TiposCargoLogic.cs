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
    public class TiposCargoLogic : ITiposCargoLogic
    {
        public TiposCargoLogic(ITiposCargoRepository tiposCargoRepository)
        {
            this.tiposCargoRepository = tiposCargoRepository;
        }
        private readonly ITiposCargoRepository tiposCargoRepository;
        public void AddTipoCargo(TiposCargo tipoCargo)
        {
            tiposCargoRepository.InsertTipoCargo(tipoCargo);
        }

        public IEnumerable<TiposCargo> GetTiposCargo()
        {
            var tiposCargo = tiposCargoRepository.ReadTiposCargo();

            return tiposCargo;
        }
    }
}
