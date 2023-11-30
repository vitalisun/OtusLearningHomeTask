using Assets.Scripts.GameManager.DI;
using Assets.Scripts.GameManager.GameSystem.Providers;
using Assets.Scripts.GameManager.ServiceLocatorFiles;
using UnityEngine;
using IServiceProvider = Assets.Scripts.GameManager.ServiceLocatorFiles.IServiceProvider;

namespace Assets.Scripts.GameManager
{
    public class GameContext : MonoBehaviour
    {
        [SerializeField]
        private GameSystem.GameManager _gameManager;

        [SerializeField]
        private ServiceLocator _serviceLocator;

        [SerializeField]
        private MonoBehaviour[] _modules;

        private void Awake()
        {
            // register listeners
            foreach (var module in _modules)
            {
                if (module is not IGameListenerProvider listenerProvider) 
                    continue;

                _gameManager.AddListeners(listenerProvider.ProvideListeners());
            }

            // register services
            foreach (var module in _modules)
            {
                if (module is not IServiceProvider serviceProvider)
                    continue;

                foreach (var (type, service) in serviceProvider.ProvideServices())
                {
                    _serviceLocator.BindService(type, service);
                }
            }

            // inject
            foreach (var module in _modules)
            {
                if (module is not IInjectProvider injectProvider) 
                    continue;

                injectProvider.Inject(_serviceLocator);
            }
        }

        private void Start()
        {
            // install
            foreach (var module in _modules)
            {
                if (module is not IInstallerProvider installerProvider) 
                    continue;

                foreach (var installer in installerProvider.ProvideInstallers())
                {
                    installer.Install();
                }
            }
        }
    }
}
