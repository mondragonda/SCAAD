using SCAAD.APIs.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SCAAD.APIs.Models;

namespace SCAAD.APIs.Data.Implementations
{
    public class PAADModificadoRepository : UpdatableRepositoryBase<PAADModificado>, IPAADModificadoRepository
    {
        public void CreatePAADModificado(PAADModificado PAADModificado)
        {
            base.Insert(PAADModificado);
        }

        public IEnumerable<PAADModificado> ReadPAADsModificados()
        {
            string[] propertiesToQuery = {"Periodo",
                                          "DescripcionesCargo",
                                          "VigenciasSNI",
                                          "PAADEstatus",
                                          "Docente"};

            string[] nestedPropertiesToQuery = {"DescripcionesCargo.Cargo",
                                                "DescripcionesCargo.Rangos",
                                                "DescripcionesCargo.TiempoCargo",
                                                "DescripcionesCargo.TipoCargo",
                                                "DescripcionesCargo.OpcionesCargo",
                                                "VigenciasSNI.SNI",
                                                "Docente.Carrera"};

            return base.Get(propertiesToQuery, nestedPropertiesToQuery);
        }

        public void RemovePAADModificado(int idPAADModificado)
        {
            var PAADToRemove = base.Get(p => p.Id == idPAADModificado).FirstOrDefault();

            base.Delete(PAADToRemove);
        }
    }
}
