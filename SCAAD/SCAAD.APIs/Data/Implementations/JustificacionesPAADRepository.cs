using SCAAD.APIs.Data.Interfaces;
using SCAAD.APIs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCAAD.APIs.Data.Implementations
{
    public class JustificacionesPAADRepository : UpdatableRepositoryBase<JustificacionPAAD>, IJustificacionesPAADRepository
    {
        public void CreateJustificacionPAAD(JustificacionPAAD justificacionPAAD)
        {
            base.Insert(justificacionPAAD);
        }

        public IEnumerable<JustificacionPAAD> ReadJustificacionesPAAD()
        {
            return base.Get().ToList();
        }

        public IEnumerable<JustificacionPAAD> ReadJustificacionesPAAD(int idPAAD)
        {
            return base.Get(j => j.PAAD_Id == idPAAD).ToList();
        }
    }
}
