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
    public class DocenteViewModelMapProfileConfiguration : Profile
    {
        protected override void Configure()
        {
            CreateMap<DocenteViewModel, Docente>()
               .ForMember(d => d.Id, d => d.MapFrom(dVM => dVM.userId))
               .ForMember(d => d.Carrera_Id, d => d.MapFrom(dVM => dVM.CarreraId))
               .ForMember(d => d.Nombre, d => d.MapFrom(dVM => dVM.Nombre))
               .ForMember(d => d.Apellido, d => d.MapFrom(dVM => dVM.Apellido))
               .ForMember(d => d.NumeroEmplado, d => d.MapFrom(dVM => dVM.NumeroEmplado));

            CreateMissingTypeMaps = true;
        }
    }
}
