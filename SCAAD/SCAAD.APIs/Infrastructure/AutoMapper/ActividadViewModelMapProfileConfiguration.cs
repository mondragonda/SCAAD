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
    public class ActividadViewModelMapProfileConfiguration : Profile
    {
        protected override void Configure()
        {
            CreateMap<ActividadViewModel, PAADActividad>()
                .ForMember(a => a.Categoria_id, a => a.MapFrom(aVM => aVM.idCategoria))
                .ForMember(a => a.Inicio, a => a.MapFrom(aVM => aVM.FechaInicio))
                .ForMember(a => a.Finalizacion, a => a.MapFrom(aVM => aVM.FechaFinalizacion))
                .ForMember(a => a.Produccion, a => a.MapFrom(aVM => aVM.Produccion))
                .ForMember(a => a.CACEI_CIEES, a => a.MapFrom(aVM => aVM.CACEI_CIEES))
                .ForMember(a => a.CuerpoAcademico, a => a.MapFrom(aVM => aVM.CuerpoAcademico))
                //.ForMember(a => a.PorcentajeAvance, a => a.MapFrom(aVM => aVM.Porcentaje))
                //.ForMember(a => a.Completado, a => a.MapFrom(aVM => aVM.Completada))
                ;

            CreateMissingTypeMaps = true;
        }
    }
}
