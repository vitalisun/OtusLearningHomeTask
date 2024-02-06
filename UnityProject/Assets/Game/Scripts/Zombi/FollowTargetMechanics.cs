using Assets.Scripts.Shared;
using UnityEngine;

public class FollowTargetMechanics
{
    private AtomicVariable<float> _speed;
    private AtomicVariable<Transform> _target;
    private readonly Transform _transform;

    public FollowTargetMechanics(AtomicVariable<float> speed, AtomicVariable<Transform> target, Transform transform)
    {
        _speed = speed;
        _target = target;
        _transform = transform;
    }

    public void Update()
    {
        _transform.position = Vector3.MoveTowards(_transform.position, _target.Value.position, _speed.Value * Time.deltaTime);
    }

}


