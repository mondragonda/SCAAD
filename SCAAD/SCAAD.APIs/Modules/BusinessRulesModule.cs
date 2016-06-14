using SCAAD.APIs.Logic;
using Autofac;
using SCAAD.APIs.Logic.Implementations;
using SCAAD.APIs.Logic.Business_Rules;
using SCAAD.APIs.Models;
using SCAAD.APIs.Models.ViewModels;

namespace SCAAD.APIs.Modules
{
    public class BusinessRulesModule : LogicModule
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterType<PAADBusinessRules>().As<ICreateEntityBusinessRules<PAADViewModel>>();
            builder.RegisterType<PAADBusinessRules>().As<IModifyEntityBusinessRules<PAADViewModel>>();
            builder.RegisterType<PeriodoBusinessRules>().As<ICreateEntityBusinessRules<Periodo>>();
            builder.RegisterType<DocenteBusinessRules>().As<ICreateEntityBusinessRules<DocenteViewModel>>();
            builder.RegisterType<VigenciaSNIBusinessRules>().As <ICreateEntityBusinessRules<VigenciaSNI>>();
            builder.RegisterType<PAADActividadBusinessRules>().As <ICreateEntityBusinessRules<PAADActividadViewModel>>();
        }
    }
}
