using EcsEngine.Components;
using System.Collections.Generic;
using System.ComponentModel;
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

        public void InitPool(GameObject[] prefabs, Transform container)
        {
            for (var i = 0; i < _initialCount; i++)
            {
                var randomNum = Random.Range(0, prefabs.Length);

                var obj = Object.Instantiate(prefabs[randomNum], container);
                _pool.Enqueue(obj);
            }
        }

        public GameObject GetFromPool(Vector3 spawnPosition, Transform worldTransform)
        {
            if (_pool.TryDequeue(out var obj))
            {
                obj.transform.SetParent(worldTransform);
                obj.transform.position = spawnPosition;
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