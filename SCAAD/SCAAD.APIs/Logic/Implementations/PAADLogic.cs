using System;
using System.Collections.Generic;
using AutoMapper;
using SCAAD.APIs.Models;
using SCAAD.APIs.Common;
using SCAAD.APIs.Data.Interfaces;
using SCAAD.APIs.Logic.Interfaces;
using SCAAD.APIs.Logic.Business_Rules;
using SCAAD.APIs.Models.ViewModels;
using System.Linq;
using SCAAD.APIs.Infrastructure.MyMapper;
using SCAAD.APIs.Infrastructure.MyMappers;
using SCAAD.APIs.Infrastructure;
using SCAAD.APIs.Data.Implementations;

namespace SCAAD.APIs.Logic.Implementations
{
    public class PAADLogic : IPAADLogic
    {
        public PAADLogic(IPAADRepository paadRepository, ICreateEntityBusinessRules<PAADViewModel> createPaadEntityBusinessRules,
                         IModifyEntityBusinessRules<PAADViewModel> modifyPaadEntityBusinessRules)
        {
            this.paadRepository = paadRepository;
            this.createPaadEntityBusinessRules = createPaadEntityBusinessRules;
            this.modifyPaadEntityBusinessRules = modifyPaadEntityBusinessRules;

        }

        private readonly IPAADRepository paadRepository;
        private readonly ICreateEntityBusinessRules<PAADViewModel> createPaadEntityBusinessRules;
        private readonly IModifyEntityBusinessRules<PAADViewModel> modifyPaadEntityBusinessRules;

        public void AddPAAD(string docenteId, PAADViewModel PAADViewModel)
        {
            PAADViewModel.DocenteId = docenteId;

            if (createPaadEntityBusinessRules.CanCreate(PAADViewModel))
            {
                var PAAD = PAADMapper.Map(PAADViewModel);
                paadRepository.CreatePAAD(PAAD);
            }
            else
            {
                throw new InvalidOperationException(PAADErrorMessages.InvalidRegister);
            }
        }

        public IEnumerable<PAAD> GetPAADs()
        {
            var existingPAADs = paadRepository.ReadPAADs();

            return existingPAADs;
        }

        public IEnumerable<PAAD> GetPAADs(int numeroEmpleado)
        {
            var existingPAADs = paadRepository.ReadPAADs(p => p.Docente.NumeroEmplado == numeroEmpleado);

            return existingPAADs;
        }
        public void RemovePAAD(PAAD PAAD)
        {
            paadRepository.DeletePAAD(PAAD);
        }

        public IEnumerable<PAAD> GetPAADsRevisionAprobacion()
        {
            var result = paadRepository.ReadPAADs(r => r.PAADEstatus_Id == Constants.PAADEstatus_RevisionParaAprobacion);
            return result;
        }

        public IEnumerable<PAADModificado> GetPAADsRevisionModificacion()
        {
            var paadModificadoRepository = new PAADModificadoRepository();

            return paadModificadoRepository.ReadPAADsModificados();
        }

        public IEnumerable<PAAD> GetPAADsCompletados()
        {
            var paadsCompletados = paadRepository.ReadPAADs(p => p.Completado == true);

            return paadsCompletados;
        }

        public void MandarPAADRevisionAprobacion(int pAAD_Id)
        {
            var PAAD = paadRepository.Get(r => r.Id == pAAD_Id).FirstOrDefault();
            PAAD.PAADEstatus_Id = Constants.PAADEstatus_RevisionParaAprobacion;
            paadRepository.Update(PAAD, r => r.PAADEstatus_Id);
        }

        public void ModificarPAAD(int pAAD_Id, PAADViewModel paaadViewModel)
        {
                var paadModificada = PAADMapper.Map(paaadViewModel);
                paadModificada.Id = pAAD_Id;

            try {
                paadRepository.Update(paadModificada,
                    r => r.Docente_Id,
                    r => r.Periodo_Id,
                    r => r.DescripcionesCargo_Id,
                    r => r.VigenciaSNI_Id,
                    r => r.VigenciaPRODEP,
                    r => r.HorasLicenciaturas,
                    r => r.HorasClase,
                    r => r.HorasPosgrado,
                    r => r.HorasGestion,
                    r => r.HorasInvestigacion,
                    r => r.HorasTutorias,
                    r => r.NombreActividadGestion);
            }catch(Exception e)
            {
                throw new ApplicationException("Hubo un error al modificar el PAAD");
            }
        }

        public void ModificarPAADJustificada(int pAAD_Id, PAADModificadoJustificadoViewModel paaadViewModel)
        {
            paaadViewModel.PAAD_Id = pAAD_Id;

            var paadModificado = PAADModificadoMapper.Map(paaadViewModel);

            var paadModificadoRepository = new PAADModificadoRepository();

            var paadOriginal = paadRepository.Get(p => p.Id == paadModificado.PAADOriginal_Id)
                                .FirstOrDefault();

            paadOriginal.PAADEstatus_Id = Common.Constants.PAADEstatus_RevisionParaModificacion;

            paadModificadoRepository.CreatePAADModificado(paadModificado);
            paadRepository.Update(paadOriginal, p => p.PAADEstatus_Id);
        }

        public void AprobarPAAD(int PAAD_Id)
        {
            var PAADToAprove = paadRepository.Get(p => p.Id == PAAD_Id).FirstOrDefault();
            PAADToAprove.PAADEstatus_Id = Common.Constants.PAADEstatus_Aprobado;

            paadRepository.Update(PAADToAprove, p => p.PAADEstatus_Id);
        }

        public void RechazarPAAD(int PAAD_Id)
        {
            var PAADToReject = paadRepository.Get(p => p.Id == PAAD_Id).FirstOrDefault();
            PAADToReject.PAADEstatus_Id = Common.Constants.PAADEstatus_Rechazado;

            paadRepository.Update(PAADToReject, p => p.PAADEstatus_Id);
        }

        public void AprobarModificacionPAAD(int idPAADModificado)
        {
            var paadModificadoRepository = new PAADModificadoRepository();

            var paadModificado = paadModificadoRepository.Get(p => p.Id == idPAADModificado)
                                 .FirstOrDefault();

            var paad = PAADAprobadoModificacionMapper.Map(paadModificado);

            paadRepository.Update(paad,
                             r => r.Docente_Id,
                             r => r.Periodo_Id,
                             r => r.DescripcionesCargo_Id,
                             r => r.VigenciaSNI_Id,
                             r => r.VigenciaPRODEP,
                             r => r.HorasLicenciaturas,
                             r => r.HorasClase,
                             r => r.HorasPosgrado,
                             r => r.HorasGestion,
                             r => r.HorasInvestigacion,
                             r => r.HorasTutorias,
                             r => r.PAADEstatus_Id,
                             r => r.NombreActividadGestion);

            var justificacionPAADRepository = new JustificacionesPAADRepository();

            var justificacionPAAD = new JustificacionPAAD()
            {
                PAAD_Id = paad.Id,
                TipoCambio_Id = Common.Constants.TipoCambio_Modificacion,
                Descripcion = paadModificado.MotivoModificacion,
                Aprobado = true,
            };

            justificacionPAADRepository.CreateJustificacionPAAD(justificacionPAAD);
            paadModificadoRepository.RemovePAADModificado(idPAADModificado);
        }

    }
}
