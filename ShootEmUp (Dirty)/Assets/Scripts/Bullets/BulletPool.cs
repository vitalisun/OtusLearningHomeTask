using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Bullets
{
    internal sealed class BulletPool
    {
        private readonly int _initialCount;
        private readonly Queue<Bullet> _pool = new();

        public BulletPool(int initialCount)
        {
            this._initialCount = initialCount;
        }

        public void InitPool(Bullet prefab, Transform container)
        {
            for (var i = 0; i < _initialCount; i++)
            {
                var bullet = UnityEngine.Object.Instantiate(prefab, container);
                _pool.Enqueue(bullet);
            }
        }

        public Bullet GetBulletFromPool(Bullet prefab, Transform worldTransform)
        {
            if (_pool.TryDequeue(out var bullet))
            {
                bullet.transform.SetParent(worldTransform);
            }
            else
            {
                bullet = UnityEngine.Object.Instantiate(prefab, worldTransform);
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
