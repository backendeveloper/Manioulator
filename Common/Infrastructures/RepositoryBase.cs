using System;

namespace Common.Infrastructures
{
    public abstract class RepositoryBase<TContext> where TContext : class, IDisposable
    {
        private readonly IServiceLocator _serviceLocator;

        protected RepositoryBase(IServiceLocator serviceLocator)
        {
            _serviceLocator = serviceLocator;
        }

        protected internal TContext DataContext => ((IDataContextFactory<TContext>)_serviceLocator.GetService(typeof(IDataContextFactory<TContext>))).GetContext();
    }
}