using System.Collections.Generic;
using UnityEngine;

namespace Assets.Game.Scripts.Zombi
{
    public sealed class ZombiPool
    {
        private readonly int _initialCount;
        private readonly Queue<Zombi> _pool = new();

        public ZombiPool(int initialCount)
        {
            _initialCount = initialCount;
        }

        public void InitPool(Zombi prefab, Transform container)
        {
            for (var i = 0; i < _initialCount; i++)
            {
                var zombi = Object.Instantiate(prefab, container);
                _pool.Enqueue(zombi);
            }
        }

        public Zombi GetZombiFromPool(Zombi prefab, Transform spawnTransform, Transform worldTransform)
        {
            if (_pool.TryDequeue(out var zombi))
            {
                zombi.transform.SetParent(worldTransform);
                zombi.transform.position = spawnTransform.position;
            }
            else
            {
                zombi = Object.Instantiate(prefab, spawnTransform.position, spawnTransform.rotation, worldTransform);
            }
            return zombi;
        }

        public void ReturnZombiToPool(Zombi zombi, Transform container)
        {
            zombi.transform.SetParent(container);
            _pool.Enqueue(zombi);
        }
    }
}
