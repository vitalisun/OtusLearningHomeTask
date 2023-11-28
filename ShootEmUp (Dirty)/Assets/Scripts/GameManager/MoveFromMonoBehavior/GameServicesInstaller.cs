using System;
using System.Collections.Generic;
using System.Reflection;
using Assets.Scripts.DI;
using Assets.Scripts.Input;
using UnityEngine;
using CharacterController = Assets.Scripts.Character.CharacterController;

namespace Assets.Scripts.GameManager
{
    public class GameServicesInstaller : MonoBehaviour,
        IServiceProvider
    {
        [SerializeField]
        private CharacterController _characterController;

        [SerializeField, Service(typeof(IInputManager))] 
        private InputManager _inputManager;

        public void Inject(ServiceLocator serviceLocator)
        {
            FieldInfo[] fields = GetType().GetFields(
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
    }
}
