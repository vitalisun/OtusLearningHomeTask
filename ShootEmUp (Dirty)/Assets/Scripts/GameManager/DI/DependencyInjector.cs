using System;
using System.Reflection;
using Assets.Scripts.GameManager.ServiceLocatorFiles;

namespace Assets.Scripts.GameManager.DI
{
    public static class DependencyInjector
    {
        /// <summary>
        /// look for methods with InjectAttribute and call InvokeConstruct
        /// </summary>
        /// <param name="target"></param>
        /// <param name="locator"></param>
        public static void Inject(object target, ServiceLocator locator)
        {
            Type type = target.GetType();
            MethodInfo[] methods = type.GetMethods(
                BindingFlags.Instance |
                BindingFlags.Public |
                BindingFlags.NonPublic |
                BindingFlags.FlattenHierarchy
            );

            foreach (MethodInfo method in methods)
            {
                if (method.IsDefined(typeof(InjectAttribute)))
                {
                    InvokeConstruct(method, target, locator);
                }
            }
        }

        /// <summary>
        /// get types of parameters, get objects of those types from locator and call method with objects instead of types as args 
        /// </summary>
        /// <param name="method"></param>
        /// <param name="target"></param>
        /// <param name="locator"></param>
        private static void InvokeConstruct(MethodInfo method, object target, ServiceLocator locator)
        {
            ParameterInfo[] parameters = method.GetParameters();

            int count = parameters.Length;
            object[] args = new object[count];

            for (int i = 0; i < count; i++)
            {
                ParameterInfo parameter = parameters[i];
                Type type = parameter.ParameterType;

                object service = locator.GetService(type);
                args[i] = service;
            }

            method.Invoke(target, args);
        }
    }
}