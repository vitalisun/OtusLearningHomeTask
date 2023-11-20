using UnityEngine;

namespace ShootEmUp
{
    public sealed class InputManager : MonoBehaviour
    {
        [SerializeField]
        private CharacterController characterController;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                characterController.FireRequired = true;
            }

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                characterController.HorizontalDirection = -1;
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                characterController.HorizontalDirection = 1;
            }
            else
            {
                characterController.HorizontalDirection = 0;
            }
        }
    }
}