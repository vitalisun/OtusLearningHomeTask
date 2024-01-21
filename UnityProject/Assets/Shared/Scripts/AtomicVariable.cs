using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Lessons.Lesson14_ModuleMechanics
{
    [Serializable]
    public class AtomicVariable<T>
    {
        private Action<T> _valueChanged;

        [OnValueChanged("OnValueChangedInEditor")]
        [SerializeField]
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

#if UNITY_EDITOR
        private void OnValueChangedInEditor(T _)
        {
            _valueChanged?.Invoke(_value);
        }
#endif
    }
}