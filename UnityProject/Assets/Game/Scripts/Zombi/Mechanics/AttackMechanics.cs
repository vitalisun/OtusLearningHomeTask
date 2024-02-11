using Assets.Game.Scripts.Shared;
using UnityEngine;

namespace Assets.Game.Scripts.Zombi.Mechanics
{
    public class AttackMechanics
    {
        private readonly AtomicVariable<ZombiStates> _state;

        private float _attackCooldown = 1;
        private readonly Player.Player _player;

        public AttackMechanics(AtomicVariable<ZombiStates> state, AtomicVariable<Transform> target)
        {
            _state = state;
            _player = target.Value.GetComponent<Player.Player>();
        }

        public void Update(float deltaTime)
        {
            if (_state.Value != ZombiStates.Attack)
            {
                return;
            }

            _attackCooldown -= deltaTime;
            if (_attackCooldown <= 0)
            {
                _player.TakeDamageEvent.Invoke(1);
                _attackCooldown = 1;
                return;
            }
        }
    }
}