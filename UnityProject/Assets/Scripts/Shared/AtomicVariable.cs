using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Assets.Scripts.Shared
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


    [Serializable]
    public sealed class AtomicEvent<T>
    {
        private event Action<T> _event;

        public void Subscribe(Action<T> action)
        {
            _event += action;
        }

        public void Unsubscribe(Action<T> action)
        {
            _event -= action;
        }

        [Button]
        public void Invoke(T args)
        {
            _event?.Invoke(args);
        }
    }
}
