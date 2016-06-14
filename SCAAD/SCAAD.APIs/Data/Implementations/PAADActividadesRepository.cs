using SCAAD.APIs.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using SCAAD.APIs.Models;
using System.Linq.Expressions;
using System.Data.Entity;

namespace SCAAD.APIs.Data.Implementations
{
    public class PAADActividadesRepository : UpdatableRepositoryBase<PAADActividad>, IPAADActividadRepository
    {
        public void CreateActividad(PAADActividad PAADActividad)
        {
            base.Insert(PAADActividad);
        }

        public IEnumerable<PAADActividad> ReadActividades(Expression<Func<PAADActividad, bool>> expresion)
        {
            var result = context.PAADActividades
                .Include(g => g.Evidencias)
                .Include(g => g.Categoria)
                .Where(expresion);

            return result.ToList();
        }

        public void UpdateActividad(int idPAADActividad, PAADActividad PAADActividad)
        {
         
        }


    }
}
