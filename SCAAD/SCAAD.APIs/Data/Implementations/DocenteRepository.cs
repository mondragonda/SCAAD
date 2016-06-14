using SCAAD.APIs.Data.Interfaces;
using SCAAD.APIs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCAAD.APIs.Data.Implementations
{
    public class DocenteRepository : UpdatableRepositoryBase<Docente>, IDocenteRepository
    {
        public void CreateDocente(Docente docente)
        {
            base.Insert(docente);
        }

        public async Task CreateDocente(string userId, Docente docente)
        {

            base.Insert(docente);
        }

        public void DeleteDocente(Docente docente)
        {
            base.Delete(docente);
        }

        public Docente ReadDocente(string id)
        {
            return base.context.Docentes.SingleOrDefault(d => d.Id == id);
        }

        public Docente ReadDocente(int numeroEmpleado)
        {
            return base.context.Docentes.SingleOrDefault(d => d.NumeroEmplado == numeroEmpleado);
        }

        public  IEnumerable<Docente> ReadDocentes()
        {
            string [] queriedProperties = { "Carrera", "PAADs"};

            var docentes = base.Get(queriedProperties);

            return docentes;
        }

        public void UpdateDocente(Docente docente)
        {
            var idDocente = docente.Id;

            base.Update(docente);
        }
    }
}
