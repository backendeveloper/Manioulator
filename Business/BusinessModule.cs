using System.Collections.Generic;
using System.IO;
using Autofac;
using Autofac.Features.Variance;
using Data;
using MediatR;

namespace Business
{
    public class BusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule<DataModule>();
            builder.RegisterSource(new ContravariantRegistrationSource());
            builder.Register(context => System.Console.Out)?.As<TextWriter>();
            builder.Register<ServiceFactory>(ctx =>
            {
                var c = ctx.Resolve<IComponentContext>();
                return t => c.Resolve(t);
            });

            var assembly = typeof(BusinessModule).Assembly;
            builder
                .RegisterAssemblyTypes(assembly)
                .Where(item => item.Name.EndsWith("Handler") && item.IsAbstract == false)
                .AsImplementedInterfaces()
                .SingleInstance();
            
            builder.RegisterAssemblyTypes(typeof(IMediator).Assembly).AsImplementedInterfaces();
            
            base.Load(builder);
        }
    }
}