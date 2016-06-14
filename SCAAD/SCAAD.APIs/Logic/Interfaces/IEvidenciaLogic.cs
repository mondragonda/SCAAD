using SCAAD.APIs.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCAAD.APIs.Logic.Interfaces
{
    public interface IEvidenciaLogic
    {
        string GetEvidenciaById(int Evidencia_Id);
        bool AgregarEvidenciaPorActividadId(EvidenciasViewModel model);
    }
}
