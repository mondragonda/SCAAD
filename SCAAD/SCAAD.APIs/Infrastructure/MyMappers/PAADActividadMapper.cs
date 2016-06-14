using SCAAD.APIs.Models;
using SCAAD.APIs.Models.ViewModels;
using System;


namespace SCAAD.APIs.Infrastructure.MyMapper
{
    public class PAADActividadMapper
    {
       public static PAADActividad Map(PAADActividadViewModel actividadViewModel)
        {
            var actividad = new PAADActividad();

            actividad.CACEI_CIEES = actividadViewModel.CACEI_CIEES;
            actividad.Categoria_id = actividadViewModel.idCategoria;
            actividad.Finalizacion = actividadViewModel.FechaFinalizacion;
            actividad.Inicio = actividadViewModel.FechaInicio;
            actividad.Produccion = actividadViewModel.Produccion;
            actividad.CuerpoAcademico = actividadViewModel.CuerpoAcademico;
            actividad.PAAD_Id = actividadViewModel.idPAAD;
            actividad.ActividadEstatus_Id = Common.Constants.ActividadEstatus_NoAcompletado;

            return actividad;
            
        }

    }
}
