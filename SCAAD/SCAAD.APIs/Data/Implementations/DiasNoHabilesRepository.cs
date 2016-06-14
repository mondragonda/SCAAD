using SCAAD.APIs.Data.Interfaces;
using SCAAD.APIs.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SCAAD.APIs.Data.Implementations
{
    public class DiasNoHabilesRepository : UpdatableRepositoryBase<DiasNoHabiles>, IDiasNoHabilesRepository
    {


        public List<DiasNoHabiles> GetDiasNoHabilesPeriodoActual(DateTime FechaInicio, DateTime FechaFinal)
        {
            return context.DiasNoHabiles.Where(x => x.Fecha >= FechaInicio && x.Fecha <= FechaFinal).ToList();
        }

        public List<DiasNoHabiles> GetDiasNoHabilesPorPeriodoId(int periodoId)
        {
            var result = context.DiasNoHabiles.Where(x => x.Periodo_Id == periodoId);
            return result.ToList();
        }

        public void InsertListDiasNohabiles(List<DiasNoHabiles> NuevosDiasNoHabiles)
        {
            context.DiasNoHabiles.AddRange(NuevosDiasNoHabiles.Where(p2 => context.DiasNoHabiles.ToList().All(p1 => p1.Fecha != p2.Fecha)));
            context.SaveChanges();
        }
    }
}