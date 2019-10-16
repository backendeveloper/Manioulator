using Autofac;

namespace Data
{
    public class DataModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
//            var services = new ServiceCollection()
//                .AddLogging();
//            
//            Container container = new Container();
//            
//            builder.Register<IDataContextFactory<DataContext>>(
//                x => new DefaultDataContextFactory<DataContext>())
//                ?.InstancePerLifetimeScope();
//            
//            builder
//                .RegisterAssemblyTypes(typeof(DataModule).Assembly)
//                .Where(item => item.Name.EndsWith("Repository") && item.IsAbstract == false)
//                .AsImplementedInterfaces()
//                .SingleInstance();
        }
    }
}