using SCAAD.APIs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCAAD.APIs.Data.Interfaces
{
    public interface IDescripcionCargoRepository
    {
        void InsertDescripcionCargo(DescripcionCargo descripcionCargo);
        IEnumerable<DescripcionCargo> ReadDescripcionesCargo();
    }
}
