using SCAAD.APIs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCAAD.APIs.Data.Interfaces
{
    public interface IRangoRepository
    {
        void InsertRango(Rango rango);
        IEnumerable<Rango> ReadRangos();
    }
}
