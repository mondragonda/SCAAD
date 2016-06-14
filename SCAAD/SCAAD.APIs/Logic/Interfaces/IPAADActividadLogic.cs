using SCAAD.APIs.Models;
using SCAAD.APIs.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCAAD.APIs.Logic.Interfaces
{
    public interface IPAADActividadLogic
    {
        void AddPAADActividad(PAADActividadViewModel PAADActividadViewModel);
        IEnumerable<PAADActividad> GetPAADActividades(int PAADId);
        void CompletarActividad(ActividadCompletadaViewModel model);
        void ModificarActividad(int actividad_Id, PAADActividadViewModel actividadiewModel);
        void ModificarActividadJustificada(int actividad_Id, ActividadModificadaViewModel actividadiewModel);
        void CancelarActividad(ActividadCanceladaViewModel actividadCanceladaViewModel);
        void AprobarModificacionActividad(int idPAADActividadModificada);
        void AprobarCancelacionActividad(int  idPAADActividad);
        void RechazarModificacionActividad(int idPAADActividadModificada);
        void RechazarCancelacionActividad(int idPAADActividad);
        IEnumerable<PAADActividad> GetActividadesEnEsperaDeCancelacion();
    }
}
