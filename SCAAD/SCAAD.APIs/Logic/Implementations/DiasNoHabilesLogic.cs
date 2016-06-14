using SCAAD.APIs.Data.Interfaces;
using SCAAD.APIs.Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SCAAD.APIs.Models;

namespace SCAAD.APIs.Logic.Implementations
{
    public class DiasNoHabilesLogic : IDiasNoHabilesLogic
    {
        private readonly IDiasNoHabilesRepository diasNoHabilesRepository;
        private readonly IPeriodoRepository periodoRepository;

        public DiasNoHabilesLogic(IDiasNoHabilesRepository diasNoHabilesRepository, IPeriodoRepository periodoRepository)
        {
            this.diasNoHabilesRepository = diasNoHabilesRepository;
            this.periodoRepository = periodoRepository;
        }

        public List<DiasNoHabiles> Get()
        {
            var periodoActual = periodoRepository.ReadPeriodoActual();

            return diasNoHabilesRepository.GetDiasNoHabilesPeriodoActual(periodoActual.FechaInicio, periodoActual.FechaFin);
        }

        public List<DiasNoHabiles> GetDiasNoHabilesPorPeriodoId(int PeriodoId)
        {
            List<DiasNoHabiles> diasNoHabiles = diasNoHabilesRepository.GetDiasNoHabilesPorPeriodoId(PeriodoId);
            return diasNoHabiles;
        }

        public void Insert(List<DiasNoHabiles> NuevaListaDiasNoHabiles)
        {
            diasNoHabilesRepository.InsertListDiasNohabiles(NuevaListaDiasNoHabiles);
            var ListaDiasNoHabilesPeriodoActual = Get();
            var ListaDiasNoHabilesABorrar = ListaDiasNoHabilesPeriodoActual.Where(c => !NuevaListaDiasNoHabiles.Select(b => b.Fecha).Contains(c.Fecha)).ToList();
            foreach (var dia in ListaDiasNoHabilesABorrar)
            {
                diasNoHabilesRepository.Delete(dia);

            }
        }
    }
}