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
    public class PAADViewModelMapProfileConfiguration : Profile
    {
        protected override void Configure()
        {

            CreateMap<PAADViewModel, PAAD>()
           .ForMember(p => p.Docente_Id, p => p.MapFrom(pVM => pVM.DocenteId))
           .ForMember(p => p.Periodo_Id, p => p.MapFrom(pVM => pVM.PeriodoId))
           .ForMember(p => p.DescripcionesCargo_Id, p => p.MapFrom(pVM => pVM.DescripcionesCargo_Id))
           .ForMember(p => p.VigenciaSNI_Id, p => p.MapFrom(pVM => pVM.VigenciaSNI_Id))
           .ForMember(p => p.VigenciaSNI_Id, p => p.MapFrom(pVM => pVM.VigenciaSNI_Id))
           .ForMember(p => p.VigenciaPRODEP, p => p.MapFrom(pVM => pVM.VigenciaPRODEP))
           .ForMember(p => p.HorasClase, p => p.MapFrom(pVM => pVM.HorasClase))
           .ForMember(p => p.HorasPosgrado, p => p.MapFrom(pVM => pVM.HorasPosgrado))
           .ForMember(p => p.HorasGestion, p => p.MapFrom(pVM => pVM.HorasGestion))
           .ForMember(p => p.HorasInvestigacion, p => p.MapFrom(pVM => pVM.HorasInvestigacion))
           .ForMember(p => p.HorasTutorias, p => p.MapFrom(pVM => pVM.HorasTutorias))
           //.ForMember(p => p.Acompletado, p => p.MapFrom(pVM => pVM.Aprobado))
           ;

            CreateMissingTypeMaps = true;

        }
    }
}
