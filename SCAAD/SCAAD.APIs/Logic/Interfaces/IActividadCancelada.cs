using SCAAD.APIs.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCAAD.APIs.Logic.Interfaces
{
    public interface IActividadCanceladaLogic
    {
        void CancelarActividad(ActividadCanceladaViewModel actividadCanceladaViewModel);
    }
}
