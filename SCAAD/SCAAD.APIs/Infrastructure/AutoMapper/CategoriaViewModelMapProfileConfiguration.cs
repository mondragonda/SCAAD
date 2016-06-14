using AutoMapper;
using SCAAD.APIs.Models;
using SCAAD.APIs.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCAAD.APIs.Infrastructure.AutoMapper
{
    class CategoriaViewModelMapProfileConfiguration : Profile
    {
        protected override void Configure()
        {
            CreateMap<CategoriaViewModel, Categoria>()
                .ForMember(c => c.Nombre, c => c.MapFrom(cVM => cVM.Nombre));

            CreateMissingTypeMaps = true;
        }
    }
}
