using Assets.Game.Scripts.Shared;
using UnityEngine;

namespace Assets.Game.Scripts.Player.Mechanics
{
    public class GetLocalMovementDirectionMechanics
    {
        private readonly AtomicVariable<Vector3> _moveDirection;
        private readonly AtomicVariable<Vector3> _localMovementDirection;
        private readonly Transform _transform;

        public GetLocalMovementDirectionMechanics(AtomicVariable<Vector3> moveDirection,
            AtomicVariable<Vector3> localMovementDirection, Transform transform)
        {
            _moveDirection = moveDirection;
            _localMovementDirection = localMovementDirection;
            _transform = transform;
        }

        public void Update()
        {
            _localMovementDirection.Value = _transform.InverseTransformDirection(_moveDirection.Value.normalized);
        }
    }
}