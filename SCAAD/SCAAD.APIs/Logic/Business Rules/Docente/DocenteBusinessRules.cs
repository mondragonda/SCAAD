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
    public class DocenteBusinessRules : ICreateEntityBusinessRules<DocenteViewModel>
    {
        public bool CanCreate(DocenteViewModel entity)
        {
            if (docenteEmployeeNumberDoesNotExistAlready(entity)
               && docenteUserIdDoesNotExistAlready(entity))
                return true;
            else
                return false;
        }
        private bool docenteEmployeeNumberDoesNotExistAlready(DocenteViewModel docente)
        {
            IDocenteRepository docentesRepository = new DocenteRepository();

            if (docentesRepository.ReadDocente(docente.NumeroEmplado) == null)
                return true;
            else
                return false;
        }
        private bool docenteUserIdDoesNotExistAlready(DocenteViewModel docente)
        {
            IDocenteRepository docentesRepository = new DocenteRepository();

            if (docentesRepository.ReadDocente(docente.userId) == null)
                return true;
            else
                return false;
        }
    }
}
