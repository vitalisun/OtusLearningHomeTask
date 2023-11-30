using System;
using System.Collections.Generic;

namespace Assets.Scripts.GameManager.ServiceLocatorFiles
{
    public interface IServiceProvider
    {
        IEnumerable<(Type, object)> ProvideServices();
    }
}