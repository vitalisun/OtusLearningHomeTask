using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Shared;
using UnityEngine;

public class Player : MonoBehaviour
{
    // data
    // speed, move direction
    public AtomicVariable<int> Speed;
    public AtomicVariable<Vector3> MoveDirection;

    // logic
    private MovementMechanics _movementMechanics;

    private void Awake()
    {
        _movementMechanics = new MovementMechanics(Speed, MoveDirection, transform);
    }

    private void Update()
    {
        _movementMechanics.Update(Time.deltaTime);
    }
}