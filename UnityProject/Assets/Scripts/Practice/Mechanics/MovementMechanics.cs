using Assets.Scripts.Shared;
using UnityEngine;

namespace Assets.Scripts.Practice.Mechanics
{
    public class MovementMechanics
    {
        private readonly AtomicVariable<Vector3> _movementDirection;
        private readonly AtomicVariable<float> _movementSpeed;
        private readonly Transform _transform;

        public MovementMechanics(AtomicVariable<Vector3> movementDirection, AtomicVariable<float> movementSpeed, Transform transform)
        {
            _movementDirection = movementDirection;
            _movementSpeed = movementSpeed;
            _transform = transform;
        }

        public void Update(float deltaTime)
        {
            _transform.Translate(_movementDirection.Value * _movementSpeed.Value * deltaTime);
        }
    }
}