using SCAAD.APIs.Models;
using SCAAD.APIs.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SCAAD.APIs.Infrastructure;
using Microsoft.AspNet.Identity;

namespace SCAAD.APIs.Logic.Interfaces
{
    public interface IDocenteLogic
    {
        //Task AddDocente(string userId, DocenteViewModel docente);
        IEnumerable<Docente> GetDocentes();
        Docente GetDocente(string id);
        Docente GetDocente(int numeroEmpleado);
        Docente GetDocente(string nombre, string apellido);
        void ModifyDocente(Docente docente);
        void RemoveDocente(Docente docente);
        Task AddDocente(Usuario user, DocenteViewModel docente);
        //Task AddDocente(ApplicationUserManager appUserManager, DocenteViewModel docente);
        Task AddDocente(ApplicationUserManager appUserManager, string userId, DocenteViewModel docente);
        Task<IdentityResult> ModificarDocente(DocenteModificarViewModel docente);
    }
}
