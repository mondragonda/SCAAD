using SCAAD.APIs.Data.Implementations;
using SCAAD.APIs.Data.Interfaces;
using SCAAD.APIs.Logic.Business_Rules;
using SCAAD.APIs.Models;
using SCAAD.APIs.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCAAD.APIs.Logic.Implementations
{
    public class PAADActividadBusinessRules : ICreateEntityBusinessRules<PAADActividadViewModel>
    {
        public bool CanCreate(PAADActividadViewModel entity)
        {
            if (PAADActividadAlreadyExists(entity) || PAADActividadIsOutsideOfCurrentPeriod(entity))
            {
                return false;
            }
            else
            {

                return true;
            }
        }


        private bool PAADActividadAlreadyExists(PAADActividadViewModel entity)
        {
            var paadActividadesRepository = new PAADActividadesRepository();

            var paadActividad = paadActividadesRepository
                                .Get(pa => pa.PAAD_Id == entity.idPAAD
                                  && pa.Categoria_id == entity.idCategoria
                                  && pa.Inicio == entity.FechaInicio
                                  && pa.Finalizacion == entity.FechaFinalizacion)
                                  .FirstOrDefault();

            if (paadActividad != null)
                return true;

            return false;
        }

        private bool PAADActividadIsOutsideOfCurrentPeriod(PAADActividadViewModel entity)
        {
            var periodoRepository = new PeriodoRepository();
            var currentPeriodo = periodoRepository.ReadPeriodoActual();

            var PAADActividadStartDate = entity.FechaInicio;
            var PAADActividadEndDate = entity.FechaFinalizacion;

            if (PAADActividadStartDate < currentPeriodo.FechaInicio
               || PAADActividadEndDate > currentPeriodo.FechaFin
               || (PAADActividadStartDate < currentPeriodo.FechaInicio
                   && PAADActividadEndDate > currentPeriodo.FechaFin))
                return true;
            else
                return false;
        }
    }
}
