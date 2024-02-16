using System.Collections.Generic;
using UnityEngine;

namespace Assets.Game.Scripts.Bullet
{
    public sealed class BulletPool
    {
        private readonly int _initialCount;
        private readonly Queue<Bullet> _pool = new();

        public BulletPool(int initialCount)
        {
            _initialCount = initialCount;
        }

        public void InitPool(Bullet prefab, Transform container)
        {
            for (var i = 0; i < _initialCount; i++)
            {
                var bullet = Object.Instantiate(prefab, container);
                _pool.Enqueue(bullet);
            }
        }

        public Bullet GetBulletFromPool(Bullet prefab, Transform spawnTransform,  Transform worldTransform)
        {
            if (_pool.TryDequeue(out var bullet))
            {
                bullet.transform.SetParent(worldTransform);
                bullet.transform.position = spawnTransform.position;
            }
            else
            {
                bullet = Object.Instantiate(prefab, spawnTransform.position, spawnTransform.rotation, worldTransform);
            }

            return bullet;
        }

        public void ReturnBulletToPool(Bullet bullet, Transform container)
        {
            bullet.transform.SetParent(container);
            _pool.Enqueue(bullet);
        }
    }
}