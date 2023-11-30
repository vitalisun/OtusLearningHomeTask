using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Bullets
{
    internal sealed class BulletPool
    {
        private readonly int _initialCount;
        private readonly Queue<Bullet> _pool = new();
        private readonly GameManager.GameSystem.GameManager _gameManager;

        public BulletPool(int initialCount, GameManager.GameSystem.GameManager gameManager)
        {
            _initialCount = initialCount;
            _gameManager = gameManager;
        }

        public void InitPool(Bullet prefab, Transform container)
        {
            for (var i = 0; i < _initialCount; i++)
            {
                var bullet = Object.Instantiate(prefab, container);
                bullet.Number = i;
                _pool.Enqueue(bullet);
                _gameManager.AddListener(bullet);
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
                bullet = Object.Instantiate(prefab, worldTransform);
                _gameManager.AddListener(bullet);
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
