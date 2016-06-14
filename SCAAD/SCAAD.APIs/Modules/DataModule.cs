using Autofac;
using SCAAD.APIs.Data;
using SCAAD.APIs.Data.Implementations;
using SCAAD.APIs.Data.Interfaces;

namespace SCAAD.APIs.Data
{
    public class DataModule : Module
    {
        public DataModule() { }

        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(c => new AuthRepository()).As<IAuthRepository>(); 
            builder.Register(c => new DiasNoHabilesRepository()).As<IDiasNoHabilesRepository>();
            builder.Register(c => new PeriodoRepository()).As<IPeriodoRepository>();
            builder.Register(c => new DocenteRepository()).As<IDocenteRepository>();
            builder.Register(c => new PAADRepository()).As<IPAADRepository>();
            builder.Register(c => new CarreraRepository()).As<ICarreraRepository>();
            builder.Register(c => new SNIRepository()).As<ISNIRepository>();
            builder.Register(c => new CargoRepository()).As<ICargoRepository>();
            builder.Register(c => new OpcionesCargoRepository()).As<IOpcionesCargoRepository>();
            builder.Register(c => new RangoRepository()).As<IRangoRepository>();
            builder.Register(c => new TiempoCargoRepository()).As<ITiempoCargoRepository>();
            builder.Register(c => new TiposCargoRepository()).As<ITiposCargoRepository>();
            builder.Register(c => new DescripcionCargoRepository()).As<IDescripcionCargoRepository>();
            builder.Register(c => new VigenciaSNIRepository()).As<IVigenciaSNIRepository>();
            builder.Register(c => new PAADActividadesRepository()).As<IPAADActividadRepository>();
            builder.Register(c => new CategoriaRepository()).As<ICategoriaRepository>();          
            builder.Register(c => new EvidenciasRepository()).As<IEvidenciasRepository>();
            builder.Register(c => new UsuarioRepository()).As<IUsuarioRepository>();
            builder.Register(c => new PAADModificadoRepository()).As<IPAADModificadoRepository>();
            builder.Register(c => new JustificacionesPAADRepository()).As<IJustificacionesPAADRepository>();



        }
    }
}