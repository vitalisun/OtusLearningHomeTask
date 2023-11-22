using System.Collections.Generic;
using Assets.Scripts.Common;
using Assets.Scripts.Components;
using Assets.Scripts.Level;
using UnityEngine;

namespace Assets.Scripts.Bullets
{
    public sealed class BulletSystem : MonoBehaviour
    {
        [SerializeField]
        private const int InitialCount = 50;

        [SerializeField] private Transform _container;
        [SerializeField] private Bullet _prefab;
        [SerializeField] private Transform _worldTransform;
        [SerializeField] private LevelBounds _levelBounds;

        private readonly HashSet<Bullet> _activeBullets = new();
        private readonly List<Bullet> _cache = new();
        private BulletPool _bulletPool;

        private void Awake()
        {
            _bulletPool = new BulletPool(InitialCount);
            _bulletPool.InitPool(_prefab, _container);
        }

        private void FixedUpdate()
        {
            RemoveOutBoundBullets();
        }

        public void FireBullet(BulletArgs args)
        {
            var bullet = _bulletPool.GetBulletFromPool(_prefab, _worldTransform);

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

                _bulletPool.ReturnBulletToPool(bullet, _container);
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
    }
}