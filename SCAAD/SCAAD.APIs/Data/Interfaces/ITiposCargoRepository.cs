using SCAAD.APIs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCAAD.APIs.Data.Interfaces
{
    public interface ITiposCargoRepository
    {
        void InsertTipoCargo(TiposCargo tipoCargo);
        IEnumerable<TiposCargo> ReadTiposCargo();
    }
}
