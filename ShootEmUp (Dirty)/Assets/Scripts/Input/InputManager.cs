using UnityEngine;

namespace ShootEmUp
{
    public sealed class InputManager : MonoBehaviour
    {
        [SerializeField]
        private CharacterController _characterController;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _characterController.FireRequired = true;
            }

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                _characterController.HorizontalDirection = -1;
            }
            else if (Input.GetKey(KeyCode.RightArrow))
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