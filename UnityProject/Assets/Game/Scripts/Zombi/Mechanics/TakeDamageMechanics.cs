using Assets.Game.Scripts.Shared;
using UnityEngine;

namespace Assets.Game.Scripts.Zombi.Mechanics
{
    public class TakeDamageMechanics
    {
        private readonly AtomicVariable<ZombiStates> _state;
        private readonly AtomicEvent _takeDamageEvent;
        private readonly AtomicEvent<Zombi> _deathEvent;
        private readonly Zombi _zombi;

        public TakeDamageMechanics(AtomicVariable<ZombiStates> state, AtomicEvent takeDamageEvent, AtomicEvent<Zombi> deathEvent, Zombi zombi)
        {
            _state = state;
            _takeDamageEvent = takeDamageEvent;
            _deathEvent = deathEvent;
            _zombi = zombi;
        }

        public void OnEnable()
        {
            _takeDamageEvent.Subscribe(OnTakeDamage);
        }

        public void OnDisable()
        {
            _takeDamageEvent.Unsubscribe(OnTakeDamage);
        }

        private void OnTakeDamage()
        {
            if (_state.Value == ZombiStates.Death)
            {
                return;  
            }

            _state.Value = ZombiStates.Death;
            _deathEvent.Invoke(_zombi);
        }
    }
}