using Assets.Scripts.Input;
using UnityEngine;

namespace Assets.Scripts.DI._1
{
    public sealed class ServiceLocatorInstaller : MonoBehaviour
    {
        [SerializeField]
        private InputManager inputManager;

        private void Awake()
        {
            ServiceLocator.BindService(typeof(IInputManager), inputManager);
        }
    }
}