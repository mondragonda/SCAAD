using SCAAD.APIs.Logic.Interfaces;
using System;
using System.Collections.Generic;
using SCAAD.APIs.Models;
using SCAAD.APIs.Data.Interfaces;
using SCAAD.APIs.Logic.Business_Rules;
using SCAAD.APIs.Logic.Business_Rules.PAADActividad;
using SCAAD.APIs.Models.ViewModels;
using AutoMapper;
using SCAAD.APIs.Infrastructure.MyMapper;
using SCAAD.APIs.Providers;
using System.Linq;
using SCAAD.APIs.Common;

namespace SCAAD.APIs.Logic.Implementations
{
    public class PAADActividadLogic : IPAADActividadLogic
    {

        public PAADActividadLogic(IPAADActividadRepository PAADActividadRepository, ICreateEntityBusinessRules<PAADActividadViewModel>
                                   createPAADActividadEntityBusinessRules,
                                    IEvidenciasRepository evidenciasRepository)
        {
            this.PAADActividadRepository = PAADActividadRepository;
            this.createPAADActividadEntityBusinessRules = createPAADActividadEntityBusinessRules;
            this.evidenciasRepository = evidenciasRepository;
        }

        private readonly IPAADActividadRepository PAADActividadRepository;
        private readonly ICreateEntityBusinessRules<PAADActividadViewModel> createPAADActividadEntityBusinessRules;
        private readonly IEvidenciasRepository evidenciasRepository;


        public void AddPAADActividad(PAADActividadViewModel PAADActividadViewModel)
        {
            if (createPAADActividadEntityBusinessRules.CanCreate(PAADActividadViewModel))
            {
                var actividad = PAADActividadMapper.Map(PAADActividadViewModel);

                PAADActividadRepository.CreateActividad(actividad);
            }
            else
            {
                throw new InvalidOperationException(PAADActividadErrorMessages.InvalidRegister);
            }

        }

        public IEnumerable<PAADActividad> GetPAADActividades(int PAADId)
        {
            var PAADActividades = PAADActividadRepository
                                    .ReadActividades(a => a.PAAD_Id == PAADId);

            return PAADActividades;
        }

        private void GenerarArchivo(int ActividadId, string Path, string descripcion)
        {

            Evidencia evidencia = new Evidencia()
            {
                PAADActividad_Id = ActividadId,
                RutaDocumento = Path,
                FechaAgregado = DateTime.Now,
                Descripcion = descripcion


            };
            evidenciasRepository.Insert(evidencia);
        }

        public void CompletarActividad(ActividadCompletadaViewModel model)
        {
            var actividad = PAADActividadRepository.Get(r => r.Id == model.Actividad_Id).FirstOrDefault();

            actividad.ActividadEstatus_Id = SCAAD.APIs.Common.Constants.ActividadEstatus_Completado;
            actividad.PorcentajeAvance = model.Porcentaje;
            actividad.Finalizacion = DateTime.Now;

            PAADActividadRepository.Update(actividad, r => r.ActividadEstatus_Id, r => r.PorcentajeAvance);

        }

        public void ModificarActividad(int actividad_Id, PAADActividadViewModel actividadViewmodel)
        {
            var actividadModificada = PAADActividadMapper.Map(actividadViewmodel);

            actividadModificada.Id = actividad_Id;
            PAADActividadRepository.Update(actividadModificada,
                r => r.Categoria_id,
                r => r.Inicio,
                r => r.Finalizacion,
                r => r.Produccion,
                r => r.CuerpoAcademico);
        }

        public void ModificarActividadJustificada(int actividad_Id, ActividadModificadaViewModel actividadViewModel)
        {
        }

        public void CancelarActividad(ActividadCanceladaViewModel actividadCanceladaViewModel)
        {
            var actividad = PAADActividadRepository.Get(r => r.Id == actividadCanceladaViewModel.Actividad_Id).FirstOrDefault();
            actividad.ActividadEstatus_Id = Constants.ActividadEstatus_RevisionParaCancelacion;

            PAADActividadRepository.Update(actividad, p => p.ActividadEstatus_Id);
        }

        public void AprobarModificacionActividad(int idPAADActividadModificada)
        {
            throw new NotImplementedException();
        }

        public void AprobarCancelacionActividad(int idPAADActividad)
        {
            //var actividad = PAADActividadRepository
            //                .ReadActividades(a => a.Id == idPAADActividad)
            //                .FirstOrDefault();

            //actividad.Cancelada = true;

            //PAADActividadRepository.Update(actividad, a => a.Cancelada);

            //var justificacionActividad = new JustificacionPAADActividades()
            //{
            //    Aprobado = true,
            //    s
            //}
            
        }

        public void RechazarModificacionActividad(int idPAADActividadModificada)
        {
            throw new NotImplementedException();
        }

        public void RechazarCancelacionActividad(int idPAADActividad)
        {
            var paadActividad = PAADActividadRepository.Get(p => p.Id == idPAADActividad)
                                .FirstOrDefault();

            paadActividad.ActividadEstatus_Id = Common.Constants.ActividadEstatus_NoAcompletado;

            PAADActividadRepository.Update(paadActividad, p => p.ActividadEstatus_Id);

        }

        public IEnumerable<PAADActividad> GetActividadesEnEsperaDeCancelacion()
        {
            return PAADActividadRepository
                .ReadActividades(a => a.ActividadEstatus_Id ==
                Common.Constants.ActividadEstatus_RevisionParaCancelacion).ToList();
        }
    }
}
