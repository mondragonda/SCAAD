using SCAAD.APIs.Common;
using SCAAD.APIs.Models;
using SCAAD.APIs.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCAAD.APIs.Infrastructure.MyMappers
{
    public class PAADMapper
    {
        public static PAAD Map(PAADViewModel PAADViewModel)
        {
            var PAAD = new PAAD();

            PAAD.Docente_Id = PAADViewModel.DocenteId;
            PAAD.Periodo_Id = PAADViewModel.PeriodoId;
            PAAD.DescripcionesCargo_Id = PAADViewModel.DescripcionesCargo_Id;
            PAAD.VigenciaSNI_Id = PAADViewModel.VigenciaSNI_Id;
            PAAD.VigenciaPRODEP = PAADViewModel.VigenciaPRODEP;
            PAAD.HorasLicenciaturas = PAADViewModel.HorasLicenciatura;
            PAAD.HorasClase = PAADViewModel.HorasClase;
            PAAD.HorasPosgrado = PAADViewModel.HorasPosgrado;
            PAAD.HorasGestion = PAADViewModel.HorasGestion;
            PAAD.HorasInvestigacion = PAADViewModel.HorasInvestigacion;
            PAAD.HorasTutorias = PAADViewModel.HorasTutorias;
            PAAD.NombreActividadGestion = PAADViewModel.NombreActividadGestion;
            PAAD.PAADEstatus_Id = Constants.PAADEstatus_Rechazado;
    

            return PAAD;
        }
    }
}
