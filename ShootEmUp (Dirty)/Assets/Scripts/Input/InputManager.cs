using UnityEngine;
using CharacterController = Assets.Scripts.Character.CharacterController;

namespace Assets.Scripts.Input
{
    public sealed class InputManager : MonoBehaviour
    {
        [SerializeField]
        private CharacterController _characterController;

        private void Update()
        {
            if (UnityEngine.Input.GetKeyDown(KeyCode.Space))
            {
                _characterController.FireRequired = true;
            }

            if (UnityEngine.Input.GetKey(KeyCode.LeftArrow))
            {
                _characterController.HorizontalDirection = -1;
            }
            else if (UnityEngine.Input.GetKey(KeyCode.RightArrow))
            {
                _characterController.HorizontalDirection = 1;
            }
            else
            {
                _characterController.HorizontalDirection = 0;
            }
        }
    }
}