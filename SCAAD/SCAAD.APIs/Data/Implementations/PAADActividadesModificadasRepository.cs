using SCAAD.APIs.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SCAAD.APIs.Models;

namespace SCAAD.APIs.Data.Implementations
{
    public class PAADActividadesModificadasRepository : UpdatableRepositoryBase<PAADActividadModificada>, IPAADActividadModificadaRepository
    {
        public void CreatePAADActividadModificada(PAADActividadModificada PAADActividadModificada)
        {
            base.Insert(PAADActividadModificada);
        }

        public IEnumerable<PAADActividadModificada> ReadPAADActividadesModificadas()
        {
            string[] propertiesToQuery = {"Categoria"
                                         ,"ActividadEstatus"};

           return base.Get(propertiesToQuery);
        }

        public void RemovePAADActividadModificada(int idPAADActividadModificada)
        {
            var PAADActividadModificadaToRemove = base.Get(pa => pa.Id == idPAADActividadModificada)
                                                      .FirstOrDefault();

            base.Delete(PAADActividadModificadaToRemove);
        }
    }
}
