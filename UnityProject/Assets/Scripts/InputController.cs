using UnityEngine;

public class InputController :  MonoBehaviour
{
    [SerializeField]
    private Player _player;

    private void Update()
    {
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
}