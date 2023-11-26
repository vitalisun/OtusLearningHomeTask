using Assets.Scripts.Input;
using UnityEngine;

namespace Assets.Scripts.DI
{
    public sealed class ServiceLocatorInstaller : MonoBehaviour
    {
        [SerializeField]
        private ServiceLocator _serviceLocator;

        [SerializeField]
        private InputManager inputManager;

        private void Awake()
        {
            _serviceLocator.BindService(typeof(IInputManager), inputManager);
        }
    }
}