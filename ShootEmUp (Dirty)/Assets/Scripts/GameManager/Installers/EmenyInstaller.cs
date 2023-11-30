using Assets.Scripts.Bullets;
using Assets.Scripts.EnemyFiles;
using Assets.Scripts.GameManager.GameSystem.Attributes;
using Assets.Scripts.GameManager.ServiceLocatorFiles;
using UnityEngine;

namespace Assets.Scripts.GameManager.Installers
{
    /// <summary>
    /// This class is used to install all the dependencies for Emeny
    /// </summary>
    public sealed class EmenyInstaller : BaseInstaller
    {
        [Listener, Installer]
        private EnemyManager _enemyManager = new();

        [SerializeField]
        private BulletConfig _bulletConfig;

        [SerializeField, Service(typeof(EnemyPositions))]
        private EnemyPositions _enemyPositions;

        [SerializeField, Service(typeof(EnemyPoolContainer))]
        private EnemyPoolContainer _enemyPoolContainer;

        [SerializeField , Service(typeof(Enemy))]
        private Enemy _enemy;

        private void Awake()
        {
            _enemyManager.BulletConfig = _bulletConfig;
        }
    }
}