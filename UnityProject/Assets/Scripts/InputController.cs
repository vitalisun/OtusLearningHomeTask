using UnityEngine;

public class InputController :  MonoBehaviour
{
    [SerializeField]
    private Player _player;

    private void Update()
    {
        RotateTowardCursor();

        if (Input.GetKey(KeyCode.W))
        {
            _player.MoveDirection.Value = Vector3.forward;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            _player.MoveDirection.Value = Vector3.back;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            _player.MoveDirection.Value = Vector3.left;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            _player.MoveDirection.Value = Vector3.right;
        }
        else
        {
            _player.MoveDirection.Value = Vector3.zero;
        }

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
}