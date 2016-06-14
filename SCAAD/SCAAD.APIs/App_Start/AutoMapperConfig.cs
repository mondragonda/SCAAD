using System;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SCAAD.APIs.Infrastructure.AutoMapper;
using Owin;

namespace SCAAD.APIs.App_Start
{
    public static class AutoMapperConfig
    {
        public static void ConfigureMapper()
        {
            Mapper.Initialize(p => p.AddProfile(new DocenteViewModelMapProfileConfiguration()));
            Mapper.Initialize(p => p.AddProfile(new PAADViewModelMapProfileConfiguration()));
            Mapper.Initialize(p => p.AddProfile(new ActividadViewModelMapProfileConfiguration()));
           
            Mapper.Initialize(p => p.AddProfile(new CategoriaViewModelMapProfileConfiguration()));

        }
    }
}
