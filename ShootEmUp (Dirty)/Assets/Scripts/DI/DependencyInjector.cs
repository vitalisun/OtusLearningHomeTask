using System;
using System.Reflection;

namespace Assets.Scripts.DI
{
    public static class DependencyInjector
    {
        public static void Inject(object target)
        {
            Type type = target.GetType();

            MethodInfo[] methods = type.GetMethods(
                BindingFlags.Instance | 
                BindingFlags.Public | 
                BindingFlags.NonPublic | 
                BindingFlags.FlattenHierarchy);

            foreach (MethodInfo method in methods)
            {
                if (method.Name == "Construct")
                {
                    InvokeConstruct(method, target);
                }
            }
        }

        private static void InvokeConstruct(MethodInfo method, object target)
        {
            ParameterInfo[] parameters = method.GetParameters();
            int count = parameters.Length;
            object[] args = new object[count];

            for (int i = 0; i < count; i++)
            {
                ParameterInfo parameter = parameters[i];
                Type parameterType = parameter.ParameterType;
                object service = ServiceLocator.GetService(parameterType);
                args[i] = service;
            }

            method.Invoke(target, args);
        }
    }
}