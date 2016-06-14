using SCAAD.APIs.Data.Implementations;
using SCAAD.APIs.Data.Interfaces;
using SCAAD.APIs.Logic.Business_Rules;
using SCAAD.APIs.Logic.Interfaces;
using SCAAD.APIs.Models;
using SCAAD.APIs.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCAAD.APIs.Logic.Implementations
{
    public class PAADBusinessRules : ICreateEntityBusinessRules<PAADViewModel>, IModifyEntityBusinessRules<PAADViewModel>
    {
        public bool CanCreate(PAADViewModel entity)
        {
            if ( DocentePAADDoesNotExistAlreadyInCurrentPeriod(entity)
                && PAADDoesNotExceedMaxHours(entity)
                && PAADIsInRegisterPeriod(entity))
            {

                return true;
            }
            else
            {
                return false;
            }
                
        }

        private bool IsPAADsDocenteInformationUpdated(PAADViewModel entity)
        {
            IDocenteRepository docenteRepository = new DocenteRepository();

            var docente = docenteRepository.ReadDocente(entity.DocenteId);

            if (docente.InformacionActualizada)
                return true;
            else
                return false;
        }

        private bool DocentePAADDoesNotExistAlreadyInCurrentPeriod(PAADViewModel paad)
        {
            IPeriodoRepository periodoRepository = new PeriodoRepository();
            var period = periodoRepository.ReadPeriodoActual();

            IPAADRepository paadRepository = new PAADRepository();

            var paadDocenteId = paad.DocenteId;

            var existingPAAD = paadRepository.ReadPAADs(paadDocenteId, period);

            if (existingPAAD == null)
                return true;
            else
                return false;
        }

        private bool PAADDoesNotExceedMaxHours(PAADViewModel paad)
        {
            var paadMaximumHours = 40;
            var paadActualHours
                = paad.HorasClase
                + paad.HorasGestion
                + paad.HorasInvestigacion
                + paad.HorasLicenciatura
                + paad.HorasPosgrado
                + paad.HorasTutorias;

            if (paadActualHours <= paadMaximumHours)
                return true;
            else
                return false;

        }

        private bool PAADIsInRegisterPeriod(PAADViewModel paad)
        {
            var paadRegisterDate = DateTime.Now;
            var maxDaysToRegister = 15;

            IPeriodoRepository periodoRepository = new PeriodoRepository();

            var period = periodoRepository.ReadPeriodoActual();

            var registerPeriodStartDate = period.FechaInicio;

            var registerPeriodEndDate = period.FechaFin;

            IDiasNoHabilesRepository diasNoHabilesRepository = new DiasNoHabilesRepository();

            var periodNonWorkingDays = diasNoHabilesRepository.GetDiasNoHabilesPeriodoActual(registerPeriodStartDate, registerPeriodEndDate).Count;

            var daysPassedSinceRegisterPeriodStart = paadRegisterDate.Subtract(registerPeriodStartDate).TotalDays - periodNonWorkingDays;

            if (daysPassedSinceRegisterPeriodStart <= maxDaysToRegister)
                return true;
            else
                return false;   
        }
        public bool CanModify(int entityId, PAADViewModel entity)
        {
            IPAADRepository PAADRepository = new PAADRepository();

            var PAADToModify = PAADRepository.Get(p => p.Id == entityId).FirstOrDefault();
            var enRevision = Common.Constants.PAADEstatus_RevisionParaAprobacion;

            if ((PAADToModify.PAADEstatus_Id != enRevision
                && PAADIsInRegisterPeriod(entity))
                || PAADOwnerIsInDirectorRole(entity))
                return true;
            else
                return false;

        }

        private bool PAADOwnerIsInDirectorRole(PAADViewModel PAAD)
        {
            IDocenteRepository docenteRepository = new DocenteRepository();
            IAuthRepository authRepository = new AuthRepository();

            var docente = docenteRepository.ReadDocente(PAAD.DocenteId);

            var PAADOwnerRoles = authRepository.GetRegisteredUserRoles(docente.idUsuario);

            if (PAADOwnerRoles.Contains(Common.Constants.Director))
                return true;
            else
                return false;
           
        }
    }
}
