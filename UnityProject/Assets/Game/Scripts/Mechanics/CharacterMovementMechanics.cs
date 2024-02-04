using Assets.Scripts.Shared;
using UnityEngine;

public class CharacterMovementMechanics
{
    private readonly AtomicVariable<float> _speed;
    private readonly AtomicVariable<Vector3> _moveDirection;
    private readonly Transform _transform;

    public CharacterMovementMechanics(AtomicVariable<float> speed, AtomicVariable<Vector3> moveDirection, Transform transform)
    {
        _speed = speed;
        _moveDirection = moveDirection;
        _transform = transform;
    }

    public void Update(float deltaTime)
    {
        _transform.Translate(_moveDirection.Value * _speed.Value * deltaTime);
    }
}