using Lessons.Lesson14_ModuleMechanics;
using System.Collections;
using System.Collections.Generic;
using Assets.Lesson14_ModuleMechanics.Scripts;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //data
    public AtomicVariable<float> Speed;
    public AtomicVariable<Vector3> MoveDirection;
    public AtomicVariable<bool> CanMove;

    public AtomicVariable<int> Damage;
    public AtomicVariable<float> LifeTime;
    public AtomicEvent Death;

    //logic
    private MovementMechanics _movementMechanics;
    private CollisionMechanics _collisionMechanics;
    private LifeTimeMechanics _lifeTimeMechanics;

    private void Awake()
    {
        _movementMechanics = new MovementMechanics(Speed, MoveDirection, transform, CanMove);
        _collisionMechanics = new CollisionMechanics(CanMove, Damage);
        _lifeTimeMechanics = new LifeTimeMechanics(LifeTime, Death, gameObject);
    }

    private void Update()
    {
        _movementMechanics.Update();
        _lifeTimeMechanics.Update();
    }

    private void OnTriggerEnter(Collider other)
    {
        _collisionMechanics.OnTriggerEnter(other);
    }
}