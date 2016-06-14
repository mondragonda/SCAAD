using SCAAD.APIs.Data.Interfaces;
using SCAAD.APIs.Logic.Interfaces;
using SCAAD.APIs.Models;
using SCAAD.APIs.Models.ViewModels;
using SCAAD.APIs.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SCAAD.APIs.Logic.Implementations
{
    public class EvidenciaLogic: IEvidenciaLogic
    {
        private readonly IEvidenciasRepository evidenciaRepository;
        //private readonly IActividadRepository actividadRepository;
        private readonly IPeriodoRepository periodoRepository;
        private readonly IDiasNoHabilesRepository diasNoHabilesRepository;
        private readonly IPAADRepository paadRepository;
        private readonly IPAADActividadRepository paadActividadRepository;
        public EvidenciaLogic(
            IEvidenciasRepository evidenciaRepository,
            //IActividadRepository actividadRepository,
            IPeriodoRepository periodoRepository,
            IDiasNoHabilesRepository diasNoHabilesRepository,
            IPAADRepository paadRepository,
            IPAADActividadRepository paadActividadRepository)
        {
            this.evidenciaRepository = evidenciaRepository;
            //this.actividadRepository = actividadRepository;
            this.periodoRepository = periodoRepository;
            this.diasNoHabilesRepository = diasNoHabilesRepository;
            this.paadRepository = paadRepository;
            this.paadActividadRepository = paadActividadRepository;
        }

        public bool AgregarEvidenciaPorActividadId(EvidenciasViewModel model)
        {

            ////var paadActividad = paadActividadRepository.Get(r => r.Actividad_Id == model.Actividad_Id).FirstOrDefault();
            ////var paad = paadRepository.Get(r => r.Id == paadActividad.PAAD_id).FirstOrDefault();            
            ////var periodo = periodoRepository.Get(r=>r.Id ==paad.Periodo_Id).FirstOrDefault();
            ////var actividad = actividadRepository.Get(r => r.Id==model.Actividad_Id).FirstOrDefault();
            //var diasNoHabiles = diasNoHabilesRepository.GetDiasNoHabilesPeriodoActual(periodo.FechaInicio, periodo.FechaFin);
            //if(DaysLeft(actividad.FechaCompletado, DateTime.Now, true, diasNoHabiles) <= 3 && actividad.NumeroArchivos<=3)
            //{
            //    string path = SaveFiles.SaveActividadesEvidencias(model.File, model.Actividad_Id);                
            //    GuardaEvidencia(model,path);
            //    return true;
            //}

            return false;


        }

        public string GetEvidenciaById(int Evidencia_Id)
        {
            var result = evidenciaRepository.Get(r => r.Id == Evidencia_Id).FirstOrDefault();
            return result==null?null: result.RutaDocumento;
        }
        private void GuardaEvidencia(EvidenciasViewModel model,string Path)
        {

            Evidencia evidencia = new Evidencia()
            {
                //Actividad_Id = model.Actividad_Id,
                RutaDocumento = Path,
                FechaAgregado = DateTime.Now,
                Descripcion = model.DescripcionArchivo                


            };
            evidenciaRepository.Insert(evidencia);

            //var actividad=actividadRepository.Get(r => r.Id == model.Actividad_Id).FirstOrDefault();
            //actividad.NumeroArchivos++;
            //actividadRepository.Update(actividad, r => r.NumeroArchivos);
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


            return count-1;
        }
    }
}