using Assets.Game.Scripts.Shared;

namespace Assets.Game.Scripts.Zombi.Mechanics
{
    public class ZombiTakeDamageMechanics
    {
        private readonly AtomicVariable<ZombiStates> _state;
        private readonly AtomicEvent<int> _takeDamageEvent;
        private readonly AtomicEvent<Zombi> _deathEvent;
        private readonly Zombi _zombi;

        public ZombiTakeDamageMechanics(
            AtomicVariable<ZombiStates> state,
            AtomicEvent<int> takeDamageEvent, 
            AtomicEvent<Zombi> deathEvent, 
            Zombi zombi)
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

        private void OnTakeDamage(int damageAmount)
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