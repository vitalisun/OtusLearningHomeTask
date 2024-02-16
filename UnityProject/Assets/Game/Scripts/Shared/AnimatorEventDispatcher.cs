using System;
using UnityEngine;

namespace Assets.Game.Scripts.Shared
{
    public sealed class AnimatorEventDispatcher : MonoBehaviour
    {
        public event Action<string> OnEventReceived;

        public void ReceiveEvent(string key)
        {
            OnEventReceived?.Invoke(key);
        }
    }
}
