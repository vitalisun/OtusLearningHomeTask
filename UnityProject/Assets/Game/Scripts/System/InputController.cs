using UnityEngine;

namespace Assets.Game.Scripts.System
{
    public class InputController :  MonoBehaviour
    {
        [SerializeField]
        private Player.Player _player;

        private readonly float _smoothTime = 0.1f;
        private Vector3 _currentMoveDirection = Vector3.zero;
        private Vector3 _velocity = Vector3.zero;

        private void Update()
        {
            Move();
            RotateTowardCursor();
            Fire();
        }

        private void Move()
        {
            Vector3 targetDirection = Vector3.zero;

            if (Input.GetKey(KeyCode.W))
            {
                targetDirection += Vector3.forward;
            }
            if (Input.GetKey(KeyCode.S))
            {
                targetDirection += Vector3.back;
            }
            if (Input.GetKey(KeyCode.A))
            {
                targetDirection += Vector3.left;
            }
            if (Input.GetKey(KeyCode.D))
            {
                targetDirection += Vector3.right;
            }

            _currentMoveDirection = Vector3.SmoothDamp(_currentMoveDirection, targetDirection, ref _velocity, _smoothTime);
            _player.MoveDirection.Value = _currentMoveDirection;
        }

        private void RotateTowardCursor()
        {
            var mousePosition = Input.mousePosition;

            var ray = Camera.main.ScreenPointToRay(mousePosition);

            if (Physics.Raycast(ray, out var hitInfo))
            {
                var targetPosition = hitInfo.point;
                _player.RotationTargetPoint.Value = targetPosition;
            }
        }

        private void Fire()
        {
            if (Input.GetMouseButtonDown(0))
            {
                _player.FireRequest.Invoke();
            }
        }
    }
}