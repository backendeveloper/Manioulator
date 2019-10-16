using System;

namespace Common.Infrastructures
{
    public interface IDataContextFactory<out TContext> : IDisposable where TContext : IDisposable
    {
        TContext GetContext();
    }
}