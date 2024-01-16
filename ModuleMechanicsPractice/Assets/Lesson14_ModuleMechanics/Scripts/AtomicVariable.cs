using System;
using UnityEngine;

namespace Lessons.Lesson14_ModuleMechanics
{
    [Serializable]
    public class AtomicVariable<T>
    {
        [SerializeField]
        private Action<T> _valueChanged;

        private T _value;

        public T Value
        {
            get => _value;
            set
            {
                _value = value;
                _valueChanged?.Invoke(value);
            }
        }

        public void Subscribe(Action<T> action)
        {
            _valueChanged += action;
        }

        public void Unsubscribe(Action<T> action)
        {
            _valueChanged -= action;
        }
    }
}