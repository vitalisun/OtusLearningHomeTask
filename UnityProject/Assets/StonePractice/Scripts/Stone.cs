using System.Collections;
using System.Collections.Generic;
using Lessons.Lesson14_ModuleMechanics;
using UnityEngine;

public class Stone : MonoBehaviour
{
    private const int DEFAULT_QUANTITY = 10;
    private const int DEFAULT_COOLDOWN = 3;

    //data
    public AtomicVariable<int> Quantity;
    public AtomicEvent<int> Dig;
    public AtomicEvent Death;
    public AtomicVariable<bool> IsDead;

    public AtomicVariable<float> CooldownTime;
    public AtomicEvent Respawn;

    //logic
    private DigMechanics _digMechanics;
    private CooldownMechanics _cooldownMechanics;

    private void Awake()
    {
        CooldownTime.Value = DEFAULT_COOLDOWN;

        _digMechanics = new DigMechanics(Quantity, Dig, Death, IsDead);
        _cooldownMechanics = new CooldownMechanics(Quantity, CooldownTime, DEFAULT_QUANTITY, DEFAULT_COOLDOWN, Respawn, IsDead);
    }

    private void Update()
    {
        _cooldownMechanics.Update();
    }

    private void OnEnable()
    {
        _digMechanics.OnEnable();
    }

    private void OnDisable()
    {
        _digMechanics.OnDisable();
    }
}