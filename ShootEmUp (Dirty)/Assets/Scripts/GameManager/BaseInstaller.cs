using Assets.Scripts.GameManager.DI;
using Assets.Scripts.GameManager.GameSystem.Providers;
using System;
using System.Collections.Generic;
using System.Reflection;
using Assets.Scripts.GameManager.GameSystem.Attributes;
using Assets.Scripts.GameManager.GameSystem.Interfaces;
using Assets.Scripts.GameManager.ServiceLocatorFiles;
using UnityEngine;
using IServiceProvider = Assets.Scripts.GameManager.ServiceLocatorFiles.IServiceProvider;

namespace Assets.Scripts.GameManager
{
    public abstract class BaseInstaller : MonoBehaviour,
        IInstallerProvider,
        IGameListenerProvider,
        IServiceProvider,
        IInjectProvider
    {

        /// <summary>
        /// get all fields with InstallerAttribute
        /// </summary>
        /// <returns></returns>
        public IEnumerable<IInstaller> ProvideInstallers()
        {
            FieldInfo[] fields = this.GetType().GetFields(
                BindingFlags.Instance |
                BindingFlags.Public |
                BindingFlags.NonPublic |
                BindingFlags.DeclaredOnly
            );

            foreach (var field in fields)
            {
                if (field.IsDefined(typeof(InstallerAttribute)) &&
                    field.GetValue(this) is IInstaller installer)
                {
                    yield return installer;
                }
            }
        }

        /// <summary>
        /// get all fields with ListenerAttribute
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Listeners.IGameListener> ProvideListeners()
        {
            FieldInfo[] fields = this.GetType().GetFields(
                BindingFlags.Instance |
                BindingFlags.Public |
                BindingFlags.NonPublic |
                BindingFlags.DeclaredOnly
            );

            foreach (var field in fields)
            {
                if (field.IsDefined(typeof(ListenerAttribute)) &&
                    field.GetValue(this) is Listeners.IGameListener gameListener)
                {
                    yield return gameListener;
                }
            }
        }

        /// <summary>
        /// get all fields with ServiceAttribute
        /// </summary>
        /// <returns></returns>
        public IEnumerable<(Type, object)> ProvideServices()
        {
            FieldInfo[] fields = this.GetType().GetFields(
                BindingFlags.Instance |
                BindingFlags.Public |
                BindingFlags.NonPublic |
                BindingFlags.DeclaredOnly
            );

            foreach (var field in fields)
            {
                var attribute = field.GetCustomAttribute<ServiceAttribute>();
                if (attribute != null)
                {
                    Type type = attribute.contract;
                    object service = field.GetValue(this);
                    yield return (type, service);
                }
            }
        }

        /// <summary>
        /// get all fields of inject provider (this and children)
        /// </summary>
        /// <param name="serviceLocator"></param>
        public virtual void Inject(ServiceLocator serviceLocator)
        {
            FieldInfo[] fields = this.GetType().GetFields(
                BindingFlags.Instance |
                BindingFlags.Public |
                BindingFlags.NonPublic |
                BindingFlags.DeclaredOnly
            );

            foreach (var field in fields)
            {
                var target = field.GetValue(this);
                DependencyInjector.Inject(target, serviceLocator);
            }
        }
    }
}
