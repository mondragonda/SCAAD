using SCAAD.APIs.Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SCAAD.APIs.Models;
using SCAAD.APIs.Data.Interfaces;

namespace SCAAD.APIs.Logic.Implementations
{
    class CategoriaLogic : ICategoriaLogic
    {
        public CategoriaLogic(ICategoriaRepository categoriaRepository)
        {
            this.categoriaRepository = categoriaRepository;
        }

        private readonly ICategoriaRepository categoriaRepository;

        public void AddCategoria(Categoria categoria)
        {
            categoriaRepository.CreateCategoria(categoria);
        }

        public IEnumerable<Categoria> GetCategorias()
        {
            var categorias = categoriaRepository.ReadCategorias();

            return categorias;
        }
    }
}
