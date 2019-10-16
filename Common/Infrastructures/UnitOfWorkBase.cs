using System;

namespace Common.Infrastructures
{
    public abstract class UnitOfWorkBase<TContext> : IUnitOfWork where TContext : class, IDisposable
    {
        private readonly IServiceLocator _serviceLocator;

        protected UnitOfWorkBase(IServiceLocator serviceLocator)
        {
            _serviceLocator = serviceLocator;

        }

        protected TContext DataContext
        {
            get
            {
                var contextFactory = (IDataContextFactory<TContext>)_serviceLocator.GetService(typeof(IDataContextFactory<TContext>));
                return contextFactory.GetContext();
            }
        }

        public abstract void Commit();
    }
}