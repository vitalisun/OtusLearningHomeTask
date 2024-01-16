using Lessons.Lesson14_ModuleMechanics;
using UnityEngine;

namespace Assets.Lesson14_ModuleMechanics.Scripts
{
    public class RotateMechanics
    {
        private AtomicVariable<Vector3> _moveDirection;
        private AtomicVariable<bool> _canMove;
        private Transform _target;
        private AtomicVariable<float> _rotationSpeed;

        public RotateMechanics(AtomicVariable<Vector3> moveDirection, Transform target, AtomicVariable<bool> canMove, AtomicVariable<float> rotationSpeed)
        {
            _moveDirection = moveDirection;
            _target = target;
            _canMove = canMove;
            _rotationSpeed = rotationSpeed;
        }

        public void Update()
        {
            if (!_canMove.Value)
            {
                return;
            }

            var rotation = Quaternion.LookRotation(_moveDirection.Value);
            _target.rotation = Quaternion.Lerp(_target.rotation, rotation, _rotationSpeed.Value * Time.deltaTime);
        }
    }
}