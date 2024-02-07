using Assets.Game.Scripts.Shared;
using UnityEngine;

namespace Assets.Game.Scripts.Zombi.Mechanics
{
    public class FollowTargetMechanics
    {
        private AtomicVariable<float> _speed;
        private AtomicVariable<Transform> _target;
        private readonly Transform _transform;
        private readonly AtomicVariable<ZombiStates> _state;

        public FollowTargetMechanics(
            AtomicVariable<float> speed,
            AtomicVariable<Transform> target,
            Transform transform,
            AtomicVariable<ZombiStates> state)
        {
            _speed = speed;
            _target = target;
            _transform = transform;
            _state = state;
        }

        public void Update()
        {
            if (_state.Value == ZombiStates.Death)
            {
                return;
            }

            var distance = Vector3.Distance(_transform.position, _target.Value.position);

            if (distance > 1.5f)
            {
                _state.Value = ZombiStates.Follow;

                _transform.position = Vector3.MoveTowards(_transform.position, _target.Value.position, _speed.Value * Time.deltaTime);
            }
            else
            {
                _state.Value = ZombiStates.Attack;
            }

        }

    }
}


