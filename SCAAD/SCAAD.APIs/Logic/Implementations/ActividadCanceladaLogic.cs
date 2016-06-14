using SCAAD.APIs.Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SCAAD.APIs.Models.ViewModels;
using SCAAD.APIs.Data.Interfaces;
using SCAAD.APIs.Models;

namespace SCAAD.APIs.Logic.Implementations
{
    public class ActividadCanceladaLogic : IActividadCanceladaLogic
    {
        public readonly IActividadCanceladaRepository actividadCanceladaRepository;
        public readonly IActividadRepository actividadRepository;


        public ActividadCanceladaLogic(
            IActividadCanceladaRepository actividadCanceladaRepository,
            IActividadRepository actividadRepository)
        {
            this.actividadCanceladaRepository = actividadCanceladaRepository;
            this.actividadRepository = actividadRepository;
        }

        public void CancelarActividad(ActividadCanceladaViewModel actividadCanceladaViewModel)
        {
            var actividadCanelada = new ActividadCancelada()
            {
                Actividad_Id = actividadCanceladaViewModel.Actividad_Id,
                Motivo = actividadCanceladaViewModel.Motivo
            };
            actividadCanceladaRepository.Insert(actividadCanelada);

            var actividad = actividadRepository.Get(r => r.Id == actividadCanceladaViewModel.Actividad_Id).FirstOrDefault();
            actividad.Cancelada = true;
            actividadRepository.Update(actividad,r=>r.Cancelada);

        }
    }
}