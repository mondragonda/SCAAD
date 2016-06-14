using SCAAD.APIs.Data.Interfaces;
using SCAAD.APIs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace SCAAD.APIs.Data.Implementations
{
    public class PeriodoRepository : UpdatableRepositoryBase<Periodo>, IPeriodoRepository
    {
        public Periodo GetPeriodoConDiasNoHabiles(int PeriodoId)
        {
            var result = context.Periodos.Include(x => x.DiasNoHabiles).Where(x => x.Id == PeriodoId).FirstOrDefault();
            return result;
        }

        public void InsertPeriodo(Periodo periodo)
        {
            base.Insert(periodo);
        }

        public Periodo ReadPeriodoActual()
        {
            var dia = DateTime.Today;

            return context.Periodos.SingleOrDefault(x => dia >= x.FechaInicio && dia <= x.FechaFin);

        }

        public IEnumerable<Periodo> ReadPeriodos()
        {
            return context.Periodos.ToList();
        }
    }
}