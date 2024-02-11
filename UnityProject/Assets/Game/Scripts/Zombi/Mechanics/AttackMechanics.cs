using Assets.Game.Scripts.Shared;
using UnityEngine;
using NotImplementedException = System.NotImplementedException;

namespace Assets.Game.Scripts.Zombi.Mechanics
{
    public class AttackMechanics
    {
        private readonly AtomicVariable<ZombiStates> _state;
        private readonly AtomicEvent _attackRequest;

        private readonly Player.Player _player;

        public AttackMechanics(
            AtomicVariable<ZombiStates> state, 
            AtomicVariable<Transform> target,
            AtomicEvent attackRequest)
        {
            _state = state;
            _attackRequest = attackRequest;
            _player = target.Value.GetComponent<Player.Player>();
        }

        public void OnEnable()
        {
            _attackRequest.Subscribe(Attack);
        }

        public void OnDisable()
        {
            _attackRequest.Unsubscribe(Attack);
        }

        private void Attack()
        {
            if (_state.Value != ZombiStates.Attack)
            {
                return;
            }

            _player.TakeDamageEvent.Invoke(1);
        }
    }
}