using System;
using SCAAD.APIs.Models;
using SCAAD.APIs.Models.ViewModels;
using System.Collections.Generic;


namespace SCAAD.APIs.Logic.Interfaces
{
    public interface IPAADLogic
    {
        void AddPAAD(string docenteId, PAADViewModel PAADViewModel);
        IEnumerable<PAAD> GetPAADs();
        IEnumerable<PAAD> GetPAADs(int numeroEmpleado);
        void RemovePAAD(PAAD PAAD);
        IEnumerable<PAAD> GetPAADsRevisionAprobacion();
        IEnumerable<PAADModificado> GetPAADsRevisionModificacion();
        IEnumerable<PAAD> GetPAADsCompletados();
        void MandarPAADRevisionAprobacion(int pAAD_Id);
        void AprobarPAAD(int PAAD_Id);
        void RechazarPAAD(int PAAD_Id);
        void AprobarModificacionPAAD(int idPAADModificado);
        void ModificarPAAD(int idPAAD, PAADViewModel paaadViewModel);
        void ModificarPAADJustificada(int idPAAD, PAADModificadoJustificadoViewModel paaadViewModel);

    }
}
