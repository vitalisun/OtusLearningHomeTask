using Assets.Scripts.Shared;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Zombi : MonoBehaviour
{
    [SerializeField] private GameObject target;

    //data
    public AtomicVariable<float> Speed = new();
    public AtomicVariable<Transform> Target;

    //logic
    private FollowTargetMechanics _followTargetMechanics;

    private void Awake()
    {
        Speed.Value = 2;
        Target.Value = target.transform;

        _followTargetMechanics = new FollowTargetMechanics(Speed, Target, transform);

    }

    private void Update()
    {
        _followTargetMechanics.Update();
    }
}

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


