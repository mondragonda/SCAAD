using SCAAD.APIs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCAAD.APIs.Data.Interfaces
{
    public interface IPAADModificadoRepository
    {
        void CreatePAADModificado(PAADModificado PAADModificado);
        void RemovePAADModificado(int idPAADModificado);
        IEnumerable<PAADModificado> ReadPAADsModificados();
    }
}
