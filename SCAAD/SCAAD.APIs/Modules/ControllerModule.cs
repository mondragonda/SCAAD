using Autofac;
using SCAAD.APIs.Controllers;
using SCAAD.APIs.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCAAD.APIs.Modules
{
    public class ControllerModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<RequestParameterValidator>().As<IRequestParametersValidator>();  
        }
    }
}
