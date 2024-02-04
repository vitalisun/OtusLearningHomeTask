using Assets.Scripts.Shared;
using UnityEngine;

public class FireMechanics
{
    private AtomicVariable<int> _bulletAmount;
    private AtomicEvent _fireRequest;
    private AtomicEvent _fireEvent;

    public FireMechanics(AtomicVariable<int> bulletAmount, AtomicEvent fireRequest, AtomicEvent fireEvent)
    {
        _bulletAmount = bulletAmount;
        _fireRequest = fireRequest;
        _fireEvent = fireEvent;
    }

    public void OnEnable()
    {
        _fireRequest.Subscribe(Fire);
    }

    public void OnDisable()
    {
        _fireRequest.Unsubscribe(Fire);
    }

    private void Fire()
    {
        if (_bulletAmount.Value > 0)
        {
            _bulletAmount.Value -= 1;
            _fireEvent.Invoke();

            Debug.Log("Bullet amount after fire: " + _bulletAmount.Value);
        }
    }
}