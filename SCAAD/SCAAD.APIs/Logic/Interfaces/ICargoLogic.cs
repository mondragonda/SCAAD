using SCAAD.APIs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCAAD.APIs.Logic.Interfaces
{
    public interface ICargoLogic
    {
        void AddCargo(Cargo cargo);
        IEnumerable<Cargo> GetCargos();
    }
}
