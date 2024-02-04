using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Shared;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Player : MonoBehaviour
{
    // data
    // speed, move direction
    public AtomicVariable<float> Speed = new();
    public AtomicVariable<Vector3> MoveDirection;
    public AtomicVariable<bool> CanMove = new();

    public AtomicVariable<Vector3> RotationTargetPoint = new();
    public AtomicVariable<int> RotationSpeed = new();

    public AtomicVariable<int> BulletAmount = new();
    public AtomicEvent FireRequest = new();
    public AtomicEvent FireEvent = new();

    // logic
    private CharacterMovementMechanics _movementMechanics;
    private RotateMechanics _rotateMechanics;
    private RestoreBulletsOverTimeMechanics _restoreBulletsOverTimeMechanics;
    private FireMechanics _fireMechanics;

    private void Awake()
    {
        Speed.Value = 5;
        RotationSpeed.Value = 5;
        CanMove.Value = true;
        _movementMechanics = new CharacterMovementMechanics(Speed, MoveDirection, transform, CanMove);
        _rotateMechanics = new RotateMechanics(RotationTargetPoint, transform, RotationSpeed);
        _restoreBulletsOverTimeMechanics = new RestoreBulletsOverTimeMechanics(BulletAmount);
        _fireMechanics = new FireMechanics(BulletAmount, FireRequest, FireEvent);
    }

    private void Update()
    {
        _movementMechanics.Update(Time.deltaTime);
        _rotateMechanics.Update(Time.deltaTime);
        _restoreBulletsOverTimeMechanics.Update(Time.deltaTime);
    }

    private void OnEnable()
    {
        _fireMechanics.OnEnable();
    }

    private void OnDisable()
    {
        _fireMechanics.OnDisable();
    }
}