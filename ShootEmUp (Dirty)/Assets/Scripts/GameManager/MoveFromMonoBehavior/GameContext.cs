using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scripts.DI;
using UnityEngine;

namespace Assets.Scripts.GameManager.MoveFromMonoBehavior
{
    public class GameContext : MonoBehaviour
    {
        [SerializeField]
        private ServiceLocator _serviceLocator;

        [SerializeField]
        private MonoBehaviour[] _modules;

        private void Awake()
        {
            foreach (var module in _modules)
            {
                if (module is IServiceProvider serviceProvider)
                {
                    var services = serviceProvider.ProvideServices();

                    foreach (var (type, service) in services)
                    {
                        _serviceLocator.BindService(type, service);
                    }

                    serviceProvider.Inject(_serviceLocator);
                }
            }
        }
    }
}
