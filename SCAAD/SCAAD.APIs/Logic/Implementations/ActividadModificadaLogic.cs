using SCAAD.APIs.Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SCAAD.APIs.Models;
using SCAAD.APIs.Data.Interfaces;
using SCAAD.APIs.Data.Implementations;
using SCAAD.APIs.Models.ViewModels;
using SCAAD.APIs.Infrastructure.MyMapper;

namespace SCAAD.APIs.Logic.Implementations
{
    public class ActividadModificadaLogic : IActividadModificadaLogic
    {
        public ActividadModificadaLogic(IActividadModificadaRepository 
                                        actividadModificadaRepository)
        {
            this.actividadModificadaRepository = actividadModificadaRepository;
        }

        private readonly IActividadModificadaRepository actividadModificadaRepository;

        public void AddActividadModificada(ActividadModificadaViewModel actividadModificadaViewModel)
        {
            var actividadModificada = ActividadModificadaMapper.Map(actividadModificadaViewModel);
            actividadModificadaRepository.CreateActividadModificada(actividadModificada);

            var PAADActividadRepository = new PAADActividadesRepository();
            var idPAADActividad = actividadModificadaViewModel.IdPAADActividad;

            PAADActividadRepository.UpdateActividad(idPAADActividad, actividadModificada.PAADActividad);

        }

        public IEnumerable<ActividadModificada> GetActividadesModificadas()
        {
            var actividadesModificadas = actividadModificadaRepository.ReadActividadesModificadas();

            return actividadesModificadas;
        }
    }
}
