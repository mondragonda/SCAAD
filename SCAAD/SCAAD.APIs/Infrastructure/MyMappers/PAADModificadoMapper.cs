using SCAAD.APIs.Models;
using SCAAD.APIs.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCAAD.APIs.Infrastructure.MyMappers
{
    public class PAADModificadoMapper
    {
        public static PAADModificado Map(PAADModificadoJustificadoViewModel paadViewModel)
        {
            var paadModificado = new PAADModificado();

            paadModificado.DescripcionCargo_Id = paadViewModel.PAADViewModel.DescripcionesCargo_Id;
            paadModificado.Docente_Id = paadViewModel.PAADViewModel.DocenteId;
            paadModificado.HorasClase = paadViewModel.PAADViewModel.HorasClase;
            paadModificado.HorasGestion = paadViewModel.PAADViewModel.HorasGestion;
            paadModificado.HorasInvestigacion = paadViewModel.PAADViewModel.HorasInvestigacion;
            paadModificado.HorasLicenciatura = paadViewModel.PAADViewModel.HorasLicenciatura;
            paadModificado.HorasPosgrado = paadViewModel.PAADViewModel.HorasPosgrado;
            paadModificado.HorasTutorias = paadViewModel.PAADViewModel.HorasTutorias;
            paadModificado.MotivoModificacion = paadViewModel.MotivoModificacion;
            paadModificado.NombreActividadGestion = paadViewModel.PAADViewModel.NombreActividadGestion;
            paadModificado.PAADEstatus_Id = Common.Constants.PAADEstatus_RevisionParaModificacion;
            paadModificado.PAADOriginal_Id = paadViewModel.PAAD_Id;
            paadModificado.Periodo_Id = paadViewModel.PAADViewModel.PeriodoId;
            paadModificado.VigenciaPRODEP = paadViewModel.PAADViewModel.VigenciaPRODEP;
            paadModificado.VigenciaSNI_Id = paadViewModel.PAADViewModel.VigenciaSNI_Id;


            return paadModificado;
        }
    }
}
