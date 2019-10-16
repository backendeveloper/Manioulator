using System;
using System.Collections.Generic;

namespace Common.Infrastructures
{
    public interface IServiceLocator
    {
        object GetService(Type serviceType);
        IEnumerable<object> GetServices(Type serviceType);
    }
}