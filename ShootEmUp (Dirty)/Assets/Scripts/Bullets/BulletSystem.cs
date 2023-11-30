using System.Collections.Generic;
using Assets.Scripts.Common;
using Assets.Scripts.Components;
using Assets.Scripts.GameManager.DI;
using Assets.Scripts.GameManager.GameSystem.Interfaces;
using Assets.Scripts.Level;
using UnityEngine;

namespace Assets.Scripts.Bullets
{
    public sealed class BulletSystem :
        IInstaller,
        Listeners.IGameFinishListener,
        Listeners.IGameFixedUpdateListener
    {
        private const int InitialCount = 50;

        private readonly HashSet<Bullet> _activeBullets = new();
        private readonly List<Bullet> _cache = new();
        private BulletPool _bulletPool;

        private Transform _bulletsContainer;
        private WorldContainer _worldContainer;
        private Bullet _prefab;
        private LevelBounds _levelBounds;
        private GameManager.GameSystem.GameManager _gameManager;

        [Inject]
        public void Construct(
            WorldContainer worldContainer,
            Bullet prefab,
            LevelBounds levelBounds,
            BulletPoolContainer bulletPoolContainer,
            GameManager.GameSystem.GameManager gameManager
            )
        {
            _worldContainer = worldContainer;
            _prefab = prefab;
            _levelBounds = levelBounds;
            _bulletsContainer = bulletPoolContainer.transform;
            _gameManager = gameManager;
        }

        public void Install()
        {
            _bulletPool = new BulletPool(InitialCount, _gameManager);
            _bulletPool.InitPool(_prefab, _bulletsContainer);
        }

        public void OnFinish()
        {
            _cache.Clear();
            _cache.AddRange(_activeBullets);

            foreach (var activeBullet in _cache)
            {
                RemoveBullet(activeBullet);
            }
        }

        public void OnFixedUpdate(float deltaTime)
        {
            RemoveOutBoundBullets();
        }

        public void FireBullet(BulletArgs args)
        {
            var bullet = _bulletPool.GetBulletFromPool(_prefab, _worldContainer.transform);

            SetBulletFlying(args, bullet);

            if (_activeBullets.Add(bullet))
            {
                bullet.OnCollisionEntered += OnBulletCollision;
            }
        }

        private void RemoveBullet(Bullet bullet)
        {
            if (_activeBullets.Remove(bullet))
            {

                bullet.OnCollisionEntered -= OnBulletCollision;

                _bulletPool.ReturnBulletToPool(bullet, _bulletsContainer);
            }
        }

        private void OnBulletCollision(Bullet bullet, Collision2D collision)
        {
            DealDamage(bullet, collision.gameObject);
            RemoveBullet(bullet);
        }

        private void RemoveOutBoundBullets()
        {
            _cache.Clear();
            _cache.AddRange(_activeBullets);

            foreach (var activeBullet in _cache)
            {
                if (!_levelBounds.InBounds(activeBullet.transform.position))
                {
                    RemoveBullet(activeBullet);
                }
            }
        }

        private static void DealDamage(Bullet bullet, GameObject other)
        {
            if (!other.TryGetComponent(out TeamComponent team))
            {
                return;
            }

            if (bullet.IsPlayer == team.IsPlayer)
            {
                return;
            }

            if (other.TryGetComponent(out HitPointsComponent hitPoints))
            {
                hitPoints.TakeDamage(bullet.Damage);
            }
        }

        private static void SetBulletFlying(BulletArgs args, Bullet bullet)
        {

            bullet.SetPosition(args.Position);
            bullet.SetColor(args.Color);
            bullet.SetPhysicsLayer(args.PhysicsLayer);
            bullet.Damage = args.Damage;
            bullet.IsPlayer = args.IsPlayer;
            bullet.SetVelocity(args.Velocity);
        }

        private static string LogArgs(BulletArgs args)
        {
            return $"Position: {args.Position}, Color: {args.Color}, PhysicsLayer: {args.PhysicsLayer}, Damage: {args.Damage}, IsPlayer: {args.IsPlayer}, Velocity: {args.Velocity}";
        }
    }
}