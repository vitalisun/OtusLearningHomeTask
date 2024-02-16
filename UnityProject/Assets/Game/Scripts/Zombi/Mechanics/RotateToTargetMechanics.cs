using Assets.Game.Scripts.Shared;
using UnityEngine;

namespace Assets.Game.Scripts.Zombi.Mechanics
{
    public class RotateToTargetMechanics
    {
        private readonly AtomicVariable<Transform> _target;
        private readonly Transform _transform;
        private readonly AtomicVariable<ZombiStates> _state;


        public RotateToTargetMechanics(AtomicVariable<Transform> target, Transform transform, AtomicVariable<ZombiStates> state)
        {
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

            _transform.LookAt(_target.Value);
        }
    }
}