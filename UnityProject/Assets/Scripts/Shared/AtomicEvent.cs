using System;
using Sirenix.OdinInspector;

namespace Assets.Scripts.Shared
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
}