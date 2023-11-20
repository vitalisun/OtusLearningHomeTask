using System.Collections.Generic;
using Assets.Scripts.Bullets;
using UnityEngine;

namespace ShootEmUp
{
    public sealed partial class BulletSystem : MonoBehaviour
    {
        [SerializeField]
        private int initialCount = 50;
        
        [SerializeField] private Transform container;
        [SerializeField] private Bullet prefab;
        [SerializeField] private Transform worldTransform;
        [SerializeField] private LevelBounds levelBounds;

        private readonly HashSet<Bullet> _activeBullets = new();

        private BulletPool _bulletPool = new();
        
        private void Awake()
        {
            _bulletPool.InitPool(prefab, container);
        }
        
        private void FixedUpdate()
        {
            RemoveOutBoundBullets();
        }

        public void FireBullet(BulletArgs args)
        {
           var bullet = _bulletPool.GetBulletFromPool(prefab, worldTransform);

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
                
                _bulletPool.ReturnBulletToPool(bullet, container);
            }
        }

        private void OnBulletCollision(Bullet bullet, Collision2D collision)
        {
            DealDamage(bullet, collision.gameObject);
            RemoveBullet(bullet);
        }

        private void RemoveOutBoundBullets()
        {
            foreach (var activeBullet in _activeBullets)
            {
                if (!levelBounds.InBounds(activeBullet.transform.position))
                {
                    RemoveBullet(activeBullet);
                }
            }
        }

        private void DealDamage(Bullet bullet, GameObject other)
        {
            if (!other.TryGetComponent(out TeamComponent team))
            {
                return;
            }

            if (bullet.isPlayer == team.IsPlayer)
            {
                return;
            }

            if (other.TryGetComponent(out HitPointsComponent hitPoints))
            {
                hitPoints.TakeDamage(bullet.damage);
            }
        }

        private void SetBulletFlying(BulletArgs args, Bullet bullet)
        {
            bullet.SetPosition(args.position);
            bullet.SetColor(args.color);
            bullet.SetPhysicsLayer(args.physicsLayer);
            bullet.damage = args.damage;
            bullet.isPlayer = args.isPlayer;
            bullet.SetVelocity(args.velocity);
        }
    }
}