using SCAAD.APIs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCAAD.APIs.Data.Interfaces
{
    public interface IDocenteRepository : IUpdatable<Docente>
    {
        Task CreateDocente(string userId, Docente docente);
        IEnumerable<Docente> ReadDocentes();
        Docente ReadDocente(string id);
        Docente ReadDocente(int numeroEmpleado);
        void UpdateDocente(Docente docente);
        void DeleteDocente(Docente docente);
        void CreateDocente(Docente docente);
    }
}
