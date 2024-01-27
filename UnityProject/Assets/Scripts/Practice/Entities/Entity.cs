using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Practice.Entities
{
    public class Entity : MonoBehaviour
    {
        private List<object> _components = new();

        public void Add<T>(T component)
        {
            _components.Add(component);
        }

        public bool TryGetComponent<T>(out T component)
        {
            for (int i = 0; i < _components.Count; i++)
            {
                if (_components[i] is T value)
                {
                    component = value;
                    return true;
                }
            }
            component = default(T);
            return false;
        }

        public T Get<T>()
        {
            for (int i = 0; i < _components.Count; i++)
            {
                if (_components[i] is T value)
                {
                    return value;
                }
            }
            throw new Exception($"Component {typeof(T)} not found");
        }
    }
}
