using Assets.Game.Scripts.Shared;
using UnityEngine;

namespace Assets.Game.Scripts.Player.Mechanics
{
    public class RotateMechanics
    {
        private readonly AtomicVariable<Vector3> _rotationTargetPoint;
        private readonly AtomicVariable<int> _rotationSpeed;
        private readonly Transform _transform;

        public RotateMechanics(AtomicVariable<Vector3> rotationTargetPoint, Transform transform, AtomicVariable<int> rotationSpeed)
        {
            _rotationTargetPoint = rotationTargetPoint;
            _transform = transform;
            _rotationSpeed = rotationSpeed;
        }

        public void Update(float deltaTime)
        {
            var targetDirection = _rotationTargetPoint.Value - _transform.position;
            targetDirection.y = 0;
            var singleStep = _rotationSpeed.Value * Time.deltaTime;
            var newDirection = Vector3.RotateTowards(_transform.forward, targetDirection, singleStep, 0.0f);

            Debug.DrawRay(_transform.position, newDirection, Color.red);

            _transform.rotation = Quaternion.LookRotation(newDirection);
        }
    }
}