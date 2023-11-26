using System;
using System.Collections.Generic;

namespace Assets.Scripts.DI
{
    public static class ServiceLocator
    {
        private static readonly Dictionary<Type, object> _services = new();

        public static object GetService(Type type)
        {
            return _services[type];
        }

        public static void BindService(Type type, object service)
        {
            _services.Add(type, service);
        }
    }
}
