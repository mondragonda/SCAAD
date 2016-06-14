using SCAAD.APIs.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SCAAD.APIs.Models;

namespace SCAAD.APIs.Data.Implementations
{
    public class ActividadModificadaRepository : UpdatableRepositoryBase<ActividadModificada>, IActividadModificadaRepository
    {
        public void CreateActividadModificada(ActividadModificada actividadModificada)
        {
            base.Insert(actividadModificada);
        }

        public IEnumerable<ActividadModificada> ReadActividadesModificadas()
        {
            var actividadesModificadas = base.Get();

            return actividadesModificadas;
        }
    }
}
