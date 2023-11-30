using Assets.Scripts.Bullets;
using Assets.Scripts.Common;
using Assets.Scripts.GameManager.GameSystem.Attributes;
using Assets.Scripts.GameManager.ServiceLocatorFiles;
using Assets.Scripts.Level;
using UnityEngine;

namespace Assets.Scripts.GameManager.Installers
{
    /// <summary>
    /// This class is used to install all the dependencies for BulletSystem
    /// </summary>
    public sealed class BulletSystemInstaller : BaseInstaller
    {
        [Listener, Installer, Service(typeof(BulletSystem))]
        private BulletSystem _bulletSystem = new();

        [SerializeField, Service(typeof(WorldContainer))]
        private WorldContainer _worldContainer;

        [SerializeField, Service(typeof(Bullet))]
        private Bullet _bulletPrefab;

        [SerializeField, Service(typeof(LevelBounds))]
        private LevelBounds _levelBounds;

        [SerializeField, Service(typeof(BulletPoolContainer))]
        private BulletPoolContainer _bulletPoolContainer;
    }
}