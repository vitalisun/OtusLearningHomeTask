using Lessons.Lesson14_ModuleMechanics;
using UnityEngine;

public class DigMechanics
{
    private AtomicVariable<int> _quantity;
    private AtomicEvent<int> _dig;
    private AtomicEvent _death;
    private AtomicVariable<bool> _isDead;

    public DigMechanics(AtomicVariable<int> quantity, AtomicEvent<int> dig, AtomicEvent death,
        AtomicVariable<bool> isDead)
    {
        _isDead = isDead;
        _quantity = quantity;
        _dig = dig;
        _death = death;
    }

    public void OnEnable()
    {
        _dig.Subscribe(OnDig);
    }

    public void OnDisable()
    {
        _dig.Unsubscribe(OnDig);
    }

    private void OnDig(int digAmount)
    {
        if (_isDead.Value)
        {
            return;
        }

        var quantity = _quantity.Value - digAmount;

        if (quantity <= 0)
        {
            _death.Invoke();
            _isDead.Value = true;
        }

        _quantity.Value = (int)Mathf.Max(0, quantity);
    }
}