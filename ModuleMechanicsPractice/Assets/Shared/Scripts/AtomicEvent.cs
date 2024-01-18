using System;
using Sirenix.OdinInspector;

namespace Lessons.Lesson14_ModuleMechanics
{
    [Serializable]
    public sealed class AtomicEvent
    {
        private event Action _event; 

        public void Subscribe(Action action)
        {
            _event += action;
        }
        
        public void Unsubscribe(Action action)
        {
            _event -= action;
        }

        [Button]
        public void Invoke()
        {
            _event?.Invoke();
        }
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