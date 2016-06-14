using SCAAD.APIs.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SCAAD.APIs.Models;

namespace SCAAD.APIs.Data.Implementations
{
    class CategoriaRepository : UpdatableRepositoryBase<Categoria>, ICategoriaRepository
    {
        public void CreateCategoria(Categoria categoria)
        {
            base.Insert(categoria);
        }

        public IEnumerable<Categoria> ReadCategorias()
        {
            var categorias = base.Get();

            return categorias;
        }
    }
}
