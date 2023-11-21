using System.Collections.Generic;
using Assets.Scripts.Bullets;
using Assets.Scripts.Common;
using UnityEngine;

namespace ShootEmUp
{
    public sealed partial class BulletSystem : MonoBehaviour
    {
        [SerializeField]
        private int initialCount = Consts.BulletPoolInitialCount;
        
        [SerializeField] private Transform container;
        [SerializeField] private Bullet prefab;
        [SerializeField] private Transform worldTransform;
        [SerializeField] private LevelBounds levelBounds;

        private readonly HashSet<Bullet> activeBullets = new();
        private readonly List<Bullet> cache= new();
        private BulletPool bulletPool;

        private void Awake()
        {
            bulletPool = new BulletPool(initialCount);
            bulletPool.InitPool(prefab, container);
        }
        
        private void FixedUpdate()
        {
            RemoveOutBoundBullets();
        }

        public void FireBullet(BulletArgs args)
        {
           var bullet = bulletPool.GetBulletFromPool(prefab, worldTransform);

            SetBulletFlying(args, bullet);

            if (activeBullets.Add(bullet))
            {
                bullet.OnCollisionEntered += OnBulletCollision;
            }
        }

        private void RemoveBullet(Bullet bullet)
        {
            if (activeBullets.Remove(bullet))
            {
                bullet.OnCollisionEntered -= OnBulletCollision;
                
                bulletPool.ReturnBulletToPool(bullet, container);
            }
        }

        private void OnBulletCollision(Bullet bullet, Collision2D collision)
        {
            DealDamage(bullet, collision.gameObject);
            RemoveBullet(bullet);
        }

        private void RemoveOutBoundBullets()
        {
            cache.Clear();
            cache.AddRange(activeBullets);

            foreach (var activeBullet in cache)
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

            if (bullet.IsPlayer == team.IsPlayer)
            {
                return;
            }

            if (other.TryGetComponent(out HitPointsComponent hitPoints))
            {
                hitPoints.TakeDamage(bullet.Damage);
            }
        }

        private void SetBulletFlying(BulletArgs args, Bullet bullet)
        {
            bullet.SetPosition(args.position);
            bullet.SetColor(args.color);
            bullet.SetPhysicsLayer(args.physicsLayer);
            bullet.Damage = args.damage;
            bullet.IsPlayer = args.isPlayer;
            bullet.SetVelocity(args.velocity);
        }
    }
}