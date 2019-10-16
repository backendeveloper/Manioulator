using Autofac;
using Business;
using FluentValidation;
using MediatR;

namespace Host
{
    public class HostModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule<BusinessModule>();
            builder.RegisterAssemblyTypes(typeof(IMediator).Assembly).AsImplementedInterfaces();
            
            AssemblyScanner
                .FindValidatorsInAssembly(typeof(HostModule).Assembly)
                ?.ForEach(result => builder
                    .RegisterType(result.ValidatorType)
                    .As(result.InterfaceType));
        }
    }
}