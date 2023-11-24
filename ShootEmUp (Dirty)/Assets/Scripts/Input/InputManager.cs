using System;
using Assets.Scripts.GameManager;
using UnityEngine;
using CharacterController = Assets.Scripts.Character.CharacterController;

namespace Assets.Scripts.Input
{
    public sealed class InputManager : MonoBehaviour,
        Listeners.IGameUpdateListener
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