using Assets.Game.Scripts.Shared;
using UnityEngine;

namespace Assets.Game.Scripts.Player.Mechanics
{
    public class PLayerTakeDamageMechanics
    {
        private readonly AtomicVariable<int> _health;
        private readonly AtomicEvent<int> _takeDamageEvent;
        private readonly AtomicEvent _deathEvent;

        public PLayerTakeDamageMechanics(AtomicVariable<int> health, AtomicEvent<int> takeDamageEvent, AtomicEvent deathEvent)
        {
            _health = health;
            _takeDamageEvent = takeDamageEvent;
            _deathEvent = deathEvent;
        }

        public void OnEnable()
        {
            _takeDamageEvent.Subscribe(TakeDamage);
        }

        public void OnDisable()
        {
            _takeDamageEvent.Unsubscribe(TakeDamage);
        }

        private void TakeDamage(int damage)
        {
            _health.Value -= damage;

            if (_health.Value <= 0)
            {
                _deathEvent.Invoke();
            }
        }

    }
}