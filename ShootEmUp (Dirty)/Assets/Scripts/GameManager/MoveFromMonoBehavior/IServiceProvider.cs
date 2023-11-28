using Assets.Scripts.DI;
using System;
using System.Collections.Generic;

namespace Assets.Scripts.GameManager
{
    public interface IServiceProvider
    {
        void Inject(ServiceLocator serviceLocator);
        IEnumerable<(Type, object)> ProvideServices();
    }
}