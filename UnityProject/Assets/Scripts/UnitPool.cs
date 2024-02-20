using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class UnitPool
    {
        private readonly int _initialCount;
        private readonly Queue<GameObject> _pool = new();

        public UnitPool(int initialCount)
        {
            _initialCount = initialCount;
        }

        public void InitPool(GameObject prefab, Transform container)
        {
            for (var i = 0; i < _initialCount; i++)
            {
                var obj = Object.Instantiate(prefab, container);
                _pool.Enqueue(obj);
            }
        }

        public GameObject GetFromPool(GameObject prefab, Transform spawnTransform, Transform worldTransform)
        {
            if (_pool.TryDequeue(out var obj))
            {
                obj.transform.SetParent(worldTransform);
                obj.transform.position = spawnTransform.position;
            }
            else
            {
                obj = Object.Instantiate(prefab, spawnTransform.position, spawnTransform.rotation, worldTransform);
            }
            return obj;
        }

        public void ReturnToPool(GameObject obj, Transform container)
        {
            obj.transform.SetParent(container);
            _pool.Enqueue(obj);
        }
    }
}