using SCAAD.APIs.Models;
using SCAAD.APIs.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCAAD.APIs.Infrastructure.MyMapper
{
    public class CategoriaMapper
    {
        public static Categoria Map(CategoriaViewModel categoriaViewModel)
        {
            var categoria = new Categoria();

            categoria.Nombre = categoriaViewModel.Nombre;

            return categoria;
        }
    }
}
