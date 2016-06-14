using SCAAD.APIs.Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SCAAD.APIs.Models;
using SCAAD.APIs.Data.Interfaces;

namespace SCAAD.APIs.Logic.Implementations
{
    public class ActividadLogic : IActividadLogic
    {
        private readonly IActividadRepository actividadRepository;
        private readonly IPeriodoRepository periodoRepository;
        private readonly IDiasNoHabilesRepository diasNoHabilesRepository;
        public ActividadLogic(IActividadRepository actividadRepository, IPeriodoRepository periodoRepository, IDiasNoHabilesRepository diasNoHabilesRepository)
        {
            this.actividadRepository = actividadRepository;
            this.periodoRepository = periodoRepository;
            this.diasNoHabilesRepository = diasNoHabilesRepository;

        }

        public bool Insert(Actividad Actividad)
        {
            //var periodoActual = periodoRepository.ReadPeriodoActual();
            //var diasNoHabilesActualPeriodo = diasNoHabilesRepository.GetDiasNoHabilesPeriodoActual(periodoActual.FechaInicio,periodoActual.FechaFin);
            List<DiasNoHabiles> dias = new List<DiasNoHabiles>()
            {
                new DiasNoHabiles() { Fecha= DateTime.Parse("21/10/2016") },
                new DiasNoHabiles() { Fecha= DateTime.Parse("21/10/2016") },
                new DiasNoHabiles() { Fecha= DateTime.Parse("21/10/2016") },
                new DiasNoHabiles() { Fecha= DateTime.Parse("21/10/2016") },
                new DiasNoHabiles() { Fecha= DateTime.Parse("21/10/2016") }
            };



            //var dias = DaysLeft(periodoActual.FechaInicio, DateTime.Now, true, diasNoHabilesActualPeriodo);
            //var periodo = periodoLogic.GetPeriodoActual();
            //if(DateTime.Now < periodo.FechaInicio)
            //{
            //    return false;
            //}
            //if(DateTime.Now > periodo.FechaInicio)
            //actividadLogic.Insert(Actividad);
            return true;
        }

        private int DaysLeft(DateTime startDate, DateTime endDate, Boolean excludeWeekends, List<DiasNoHabiles> excludeDates)
        {
            int count = 0;
            for (DateTime index = startDate; index < endDate; index = index.AddDays(1))
            {
                if (excludeWeekends && index.DayOfWeek != DayOfWeek.Sunday && index.DayOfWeek != DayOfWeek.Saturday)
                {
                    bool excluded = false; ;
                    for (int i = 0; i < excludeDates.Count; i++)
                    {
                        if (index.Date.CompareTo(excludeDates[i].Fecha) == 0)
                        {
                            excluded = true;
                            break;
                        }
                    }

                    if (!excluded)
                    {
                        count++;
                    }
                }
            }

            return count;
        }
    }
}