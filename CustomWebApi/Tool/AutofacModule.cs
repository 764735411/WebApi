using Autofac;
using CustomWebApi.Repository;
using CustomWebApi.Service;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomWebApi.Tool
{
    public class AutofacModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // The generic ILogger<TCategoryName> service was added to the ServiceCollection by ASP.NET Core.
            // It was then registered with Autofac using the Populate method. All of this starts
            // with the `UseServiceProviderFactory(new AutofacServiceProviderFactory())` that happens in Program and registers Autofac
            // as the service provider.
  /*          builder.Register(c => new CustomService(c.Resolve<ILogger<CustomService>>()))
                .As<ICustomService>()
                .InstancePerLifetimeScope();*/
            //注册类
            builder.RegisterType<CustomService>().As<ICustomService>();
            builder.RegisterType<CustomRepository>().As<ICustomRepository>();
            builder.RegisterType<PageTool>().As<PageTool>();
        }
    }
}
