using Autofac;
using SCAAD.APIs.Logic.Implementations;
using SCAAD.APIs.Logic.Interfaces;

namespace SCAAD.APIs.Logic
{
    public class LogicModule : Module
    {
        public LogicModule() { }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AuthLogic>().As<IAuthLogic>();
            builder.RegisterType<DiasNoHabilesLogic>().As<IDiasNoHabilesLogic>();
            builder.RegisterType<DocenteLogic>().As<IDocenteLogic>();
            builder.RegisterType<PAADLogic>().As<IPAADLogic>();
            builder.RegisterType<CarreraLogic>().As<ICarreraLogic>();
            builder.RegisterType<SNILogic>().As<ISNILogic>();
            builder.RegisterType<CargoLogic>().As<ICargoLogic>();
            builder.RegisterType<OpcionesCargoLogic>().As<IOpcionesCargoLogic>();
            builder.RegisterType<RangoLogic>().As<IRangoLogic>();
            builder.RegisterType<TiempoCargoLogic>().As<ITiempoCargoLogic>();
            builder.RegisterType<TiposCargoLogic>().As<ITiposCargoLogic>();
            builder.RegisterType<PeriodoLogic>().As<IPeriodoLogic>();
            builder.RegisterType<DescripcionCargoLogic>().As<IDescripcionCargoLogic>();
            builder.RegisterType<VigenciaSNILogic>().As<IVigenciaSNILogic>();
            builder.RegisterType<PAADActividadLogic>().As<IPAADActividadLogic>();
            builder.RegisterType<CategoriaLogic>().As<ICategoriaLogic>();
            builder.RegisterType<EvidenciaLogic>().As<IEvidenciaLogic>();


        }
    }
}