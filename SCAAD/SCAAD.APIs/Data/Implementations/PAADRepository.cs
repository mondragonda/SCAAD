using SCAAD.APIs.Data.Interfaces;
using SCAAD.APIs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SCAAD.APIs.Data.Implementations
{
    public class PAADRepository : UpdatableRepositoryBase<PAAD>, IPAADRepository
    {
        public void CreatePAAD(PAAD PAAD)
        {
            base.Insert(PAAD);
        }
        public void UpdatePAAD(PAAD PAAD)
        {
            base.Update(PAAD);
        }

        public IEnumerable<PAAD> ReadPAADs()
        {
            var PAADS = base.Get();

            return PAADS;
        }

        public IEnumerable<PAAD> ReadPAADs(Expression<Func<PAAD, bool>> expresion)
        {
            string[] propertiesToQuery = {"Periodo",
                                          "Docente",
                                          "DescripcionesCargo",
                                          "VigenciasSNI",
                                          "PAADEstatus",
                                          "PAADActividades"};

            string[] nestedPropertiesToQuery = {"DescripcionesCargo.Cargo",
                                                "Docente.Carrera",
                                                "DescripcionesCargo.Rangos",
                                                "DescripcionesCargo.TiempoCargo",
                                                "DescripcionesCargo.TipoCargo",
                                                "DescripcionesCargo.OpcionesCargo",
                                                "VigenciasSNI.SNI"};

            var PAADS = base.Get(expresion, propertiesToQuery, nestedPropertiesToQuery);

            return PAADS;
        }

        public void DeletePAAD(PAAD PAAD)
        {
            base.Delete(PAAD);
        }

        public PAAD ReadPAADs(string docenteId, Periodo periodoActual)
        {
            var PAAD = base.Get(p => p.Periodo.Id == periodoActual.Id && p.Docente_Id == docenteId).FirstOrDefault();

            return PAAD;
        }
    }
}
