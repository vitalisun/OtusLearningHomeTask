using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scripts.Common;
using ShootEmUp;
using UnityEngine;

namespace Assets.Scripts.Bullets
{
    internal class BulletPool
    {
        private readonly int initialCount;
        private readonly Queue<Bullet> pool = new();

        public BulletPool(int initialCount)
        {
            this.initialCount = initialCount;
        }

        public void InitPool(Bullet prefab, Transform container)
        {
            for (var i = 0; i < initialCount; i++)
            {
                var bullet = UnityEngine.Object.Instantiate(prefab, container);
                pool.Enqueue(bullet);
            }
        }

        public Bullet GetBulletFromPool(Bullet prefab, Transform worldTransform)
        {
            if (pool.TryDequeue(out var bullet))
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
            pool.Enqueue(bullet);
        }
    }
}
