using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShootEmUp;
using UnityEngine;

namespace Assets.Scripts.Bullets
{
    internal class BulletPool
    {
        private readonly int _initialCount = 50;

        private readonly Queue<Bullet> _bulletPool = new();

        public void InitPool(Bullet prefab, Transform container)
        {
            for (var i = 0; i < this._initialCount; i++)
            {
                var bullet = UnityEngine.Object.Instantiate(prefab, container);
                this._bulletPool.Enqueue(bullet);
            }
        }

        public Bullet GetBulletFromPool(Bullet prefab, Transform worldTransform)
        {
            if (_bulletPool.TryDequeue(out var bullet))
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
            _bulletPool.Enqueue(bullet);
        }
    }
}
