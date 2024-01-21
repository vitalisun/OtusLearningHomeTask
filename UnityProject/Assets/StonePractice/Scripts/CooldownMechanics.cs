using Lessons.Lesson14_ModuleMechanics;
using UnityEngine;

public class CooldownMechanics
{
    private readonly int _defaultQuantity;
    private readonly float _defaultCooldown;

    private AtomicVariable<float> _cooldownTime;
    private AtomicVariable<int> _quantity;
    private AtomicEvent _respawn;
    private AtomicVariable<bool> _isDead;

    public CooldownMechanics(AtomicVariable<int> quantity,
        AtomicVariable<float> cooldownTime,
        int defaultQuantity,
        float defaultCooldown,
        AtomicEvent respawn, AtomicVariable<bool> isDead)
    {
        _isDead = isDead;
        _respawn = respawn;
        _cooldownTime = cooldownTime;
        _defaultQuantity = defaultQuantity;
        _defaultCooldown = defaultCooldown;
        _quantity = quantity;
    }

    public void Update()
    {
        if (_quantity.Value > 0)
        {
            return;
        }

        if (_cooldownTime.Value <= 0)
        {
            _respawn.Invoke();
            _quantity.Value = _defaultQuantity;
            _cooldownTime.Value = _defaultCooldown;
            _isDead.Value = false;
        }

        _cooldownTime.Value -= Time.deltaTime;
    }
}