using SCAAD.APIs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCAAD.APIs.Data.Interfaces
{
    public interface IJustificacionesPAADRepository
    {
        void CreateJustificacionPAAD(JustificacionPAAD justificacionPAAD);
        IEnumerable<JustificacionPAAD> ReadJustificacionesPAAD();
        IEnumerable<JustificacionPAAD> ReadJustificacionesPAAD(int idPAAD);
    }
}
