using Assets.Scripts.Shared;
using UnityEngine;

public class MovementMechanics
{
    private readonly AtomicVariable<int> _speed;
    private readonly AtomicVariable<Vector3> _moveDirection;
    private readonly Transform _transform;

    public MovementMechanics(AtomicVariable<int> speed, AtomicVariable<Vector3> moveDirection, Transform transform)
    {
        _speed = speed;
        _moveDirection = moveDirection;
        _transform = transform;
    }

    public void Update(float deltaTime)
    {
        _transform.Translate(_moveDirection.Value * _speed.Value * deltaTime, Space.World);
    }
}