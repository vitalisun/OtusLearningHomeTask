using System;
using UnityEngine;
using CharacterController = Assets.Scripts.Character.CharacterController;

namespace Assets.Scripts.Input
{
    public sealed class InputManager : MonoBehaviour
    {
        public event Action<bool> OnFireEvent;

        public event Action<float> OnMoveEvent;

        private void Update()
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