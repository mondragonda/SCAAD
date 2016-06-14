using SCAAD.APIs.Logic.Interfaces;
using System;
using System.Collections.Generic;
using AutoMapper;
using System.Threading.Tasks;
using SCAAD.APIs.Models;
using SCAAD.APIs.Data.Interfaces;
using SCAAD.APIs.Logic.Business_Rules.Docente;
using SCAAD.APIs.Logic.Business_Rules;
using SCAAD.APIs.Models.ViewModels;
using SCAAD.APIs.Infrastructure;
using Microsoft.AspNet.Identity;
using SCAAD.APIs.Infrastructure.MyMapper;

namespace SCAAD.APIs.Logic.Implementations
{
    public class DocenteLogic : IDocenteLogic
    {
        public DocenteLogic(IDocenteRepository docentesRepository, 
                            ICreateEntityBusinessRules<DocenteViewModel> createDocenteEntityBusinessRules,
                            IAuthRepository authRepository)
        {
            this.docentesRepository = docentesRepository;
            this.createDocenteEntityBusinessRules = createDocenteEntityBusinessRules;
            this.authLogic = authRepository;
        }

        private readonly IDocenteRepository docentesRepository;
        private readonly ICreateEntityBusinessRules<DocenteViewModel> createDocenteEntityBusinessRules;
        private readonly IAuthRepository authLogic;

        public async Task AddDocente(Usuario user, DocenteViewModel docenteViewModel)
        {
            docenteViewModel.userId = user.Id;

            if (createDocenteEntityBusinessRules.CanCreate(docenteViewModel))
            {
                var docente = Mapper.Map<Docente>(docenteViewModel);
                docente.Id = Guid.NewGuid().ToString();
                await docentesRepository.CreateDocente(user.Id, docente);

            }
               
            else
                throw new InvalidOperationException(DocenteErrorMessages.DocenteAlreadyExists);     
        }

        public IEnumerable<Docente> GetDocentes()
        {
            var existingDocentes = docentesRepository.ReadDocentes();

            return existingDocentes;
        }
        public Docente GetDocente(string id)
        {
            return docentesRepository.ReadDocente(id);
        }


        public Docente GetDocente(int numeroEmpleado)
        {
            throw new NotImplementedException();
        }

        public Docente GetDocente(string nombre, string apellido)
        {
            throw new NotImplementedException();
        }

        public void ModifyDocente(Docente docente)
        {
            docentesRepository.UpdateDocente(docente);
        }
        
        public void RemoveDocente(Docente docente)
        {
            docentesRepository.DeleteDocente(docente);
        }

        public async Task AddDocente(ApplicationUserManager appUserManager,string userId, DocenteViewModel docenteViewModel)
        {
            var user = await appUserManager.FindByIdAsync(userId);

            docenteViewModel.userId = user.Id;

            if (createDocenteEntityBusinessRules.CanCreate(docenteViewModel))
            {
                var docente = DocenteMapper.Map(docenteViewModel);

                docente.Id = Guid.NewGuid().ToString();
                docente.InformacionActualizada = true;

                docentesRepository.CreateDocente(docente);

                user.Docente_Id = docente.Id;

                await appUserManager.UpdateAsync(user);

            }

            else
                throw new InvalidOperationException(DocenteErrorMessages.DocenteAlreadyExists);
        }

        public async Task<IdentityResult> ModificarDocente(DocenteModificarViewModel docenteViewModel)
        {
            IdentityResult result = await authLogic.ChangePassword(docenteViewModel.UserId,docenteViewModel.Password);
            if (!result.Succeeded)
                return result;
            var DocenteUser = await authLogic.FindUser(docenteViewModel.UserId);
            var Docente = Mapper.Map<Docente>(docenteViewModel);
            Docente.Id = DocenteUser.Docente_Id;
            docentesRepository.Update(Docente, r => r.Nombre, r => r.Apellido, r => r.Carrera_Id);

            return result;
        }
    }
}
