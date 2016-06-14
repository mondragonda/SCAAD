using SCAAD.APIs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCAAD.APIs.Infrastructure.MyMappers
{
    public class PAADAprobadoModificacionMapper
    {
        public static PAAD Map(PAADModificado PAADModificado)
        {
            var PAAD = new PAAD();

            PAAD.DescripcionesCargo_Id = PAADModificado.DescripcionCargo_Id;
            PAAD.Docente_Id = PAADModificado.Docente_Id;
            PAAD.Id = PAADModificado.PAADOriginal_Id;
            PAAD.HorasClase = PAADModificado.HorasClase;
            PAAD.HorasGestion = PAADModificado.HorasGestion;
            PAAD.HorasInvestigacion = PAADModificado.HorasInvestigacion;
            PAAD.HorasLicenciaturas = PAADModificado.HorasLicenciatura;
            PAAD.HorasPosgrado = PAADModificado.HorasPosgrado;
            PAAD.HorasTutorias = PAADModificado.HorasTutorias;
            PAAD.NombreActividadGestion = PAADModificado.NombreActividadGestion;
            PAAD.PAADEstatus_Id = Common.Constants.PAADEstatus_AprobadoParaModificacion;
            PAAD.Periodo_Id = PAADModificado.Periodo_Id;
            PAAD.VigenciaPRODEP = PAADModificado.VigenciaPRODEP;
            PAAD.VigenciaSNI_Id = PAADModificado.VigenciaSNI_Id;

            return PAAD;
        }
    }
}
