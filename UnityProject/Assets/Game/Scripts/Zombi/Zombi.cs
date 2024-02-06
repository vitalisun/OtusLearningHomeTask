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
    private RotateToTargetMechanics _rotateToTargetMechanics;

    private void Awake()
    {
        Speed.Value = 2;
        Target.Value = target.transform;

        _followTargetMechanics = new FollowTargetMechanics(Speed, Target, transform);
        _rotateToTargetMechanics = new RotateToTargetMechanics(Target, transform);
    }

    private void Update()
    {
        _followTargetMechanics.Update();
        _rotateToTargetMechanics.Update();
    }
}

public class RotateToTargetMechanics
{
    private AtomicVariable<Transform> _target;
    private readonly Transform _transform;


    public RotateToTargetMechanics(AtomicVariable<Transform> target, Transform transform)
    {
        _target = target;
        _transform = transform;
    }

    public void Update()
    {
        _transform.LookAt(_target.Value);
    }
}
