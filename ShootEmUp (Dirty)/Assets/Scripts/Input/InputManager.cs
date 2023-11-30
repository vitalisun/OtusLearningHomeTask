using System;
using Assets.Scripts.GameManager.GameSystem.Interfaces;
using UnityEngine;

namespace Assets.Scripts.Input
{
    public sealed class InputManager :
        Listeners.IGameUpdateListener, IInputManager
    {
        public event Action<bool> OnFireEvent;

        public event Action<float> OnMoveEvent;

        public void OnUpdate(float deltaTime)
        {
            if (UnityEngine.Input.GetKeyDown(KeyCode.Space))
            {
                OnFireEvent?.Invoke(true);
            }

            if (UnityEngine.Input.GetKey(KeyCode.LeftArrow))
            {
                OnMoveEvent?.Invoke(-1);
            }
            else if (UnityEngine.Input.GetKey(KeyCode.RightArrow))
            {
                OnMoveEvent?.Invoke(1);
            }
            else
            {
                OnMoveEvent?.Invoke(0);
            }
        }
    }
}