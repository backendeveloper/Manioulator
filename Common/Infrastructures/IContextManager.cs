using System;

namespace Common.Infrastructures
{
    public interface IContextManager : IDisposable
    {
        void Release();
    }
}