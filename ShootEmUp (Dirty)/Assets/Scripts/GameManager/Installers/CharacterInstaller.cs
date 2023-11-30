using Assets.Scripts.Bullets;
using Assets.Scripts.CharacterFiles;
using Assets.Scripts.GameManager.GameSystem.Attributes;
using Assets.Scripts.GameManager.ServiceLocatorFiles;
using Assets.Scripts.Input;
using UnityEngine;
using CharacterController = Assets.Scripts.CharacterFiles.CharacterController;

namespace Assets.Scripts.GameManager.Installers
{
    /// <summary>
    /// This class is used to install all the dependencies for CharacterController
    /// </summary>
    public sealed class CharacterInstaller : BaseInstaller
    {
        [Listener, Installer]
        private CharacterController _characterController = new();

        [Listener, Service(typeof(IInputManager))]
        private readonly InputManager _inputManager = new();

        [SerializeField, Service(typeof(Character))]
        private Character _character;

        [SerializeField, Service(typeof(BulletConfig))]
        private BulletConfig _bulletConfig;

        [SerializeField, Service(typeof(GameSystem.GameManager))]
        private GameSystem.GameManager _gameManager;
    }
}
