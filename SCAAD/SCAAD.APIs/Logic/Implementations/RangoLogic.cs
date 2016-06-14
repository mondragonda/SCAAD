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
    public class RangoLogic : IRangoLogic
    {
        public RangoLogic(IRangoRepository rangoRepository)
        {
            this.rangoRepository = rangoRepository;
        }
        private readonly IRangoRepository rangoRepository;
        public void AddRango(Rango rango)
        {
            rangoRepository.InsertRango(rango);
        }

        public IEnumerable<Rango> GetRangos()
        {
            var rangos = rangoRepository.ReadRangos();

            return rangos;
        }
    }
}
