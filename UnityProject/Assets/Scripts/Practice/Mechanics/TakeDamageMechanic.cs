using Assets.Scripts.Shared;
using UnityEngine;

namespace Assets.Scripts.Practice.Mechanics
{
    public class TakeDamageMechanic
    {
        private readonly AtomicVariable<int> _health;
        private readonly AtomicEvent<int> _takeDamageEvent;
        private readonly AtomicEvent _deathRequest;
        private readonly AtomicVariable<bool> _isDead;

        public TakeDamageMechanic(AtomicVariable<int> health, AtomicEvent<int> takeDamageEvent, AtomicEvent deathRequest, AtomicVariable<bool> isDead)
        {
            _health = health;
            _takeDamageEvent = takeDamageEvent;
            _deathRequest = deathRequest;
            _isDead = isDead;
        }

        public void OnEnable()
        {
            _takeDamageEvent.Subscribe(TakeDamage);
        }


        public void OnDisable()
        {
            _takeDamageEvent.Unsubscribe(TakeDamage);
        }

        private void TakeDamage(int damagePoints)
        {

            if (_health.Value > 0)
            {
                _health.Value = Mathf.Max(0, _health.Value - damagePoints);
            }

            if (!_isDead.Value && _health.Value <= 0)
            {
                _isDead.Value = true;
                _deathRequest.Invoke();
            }
        }

    }
}