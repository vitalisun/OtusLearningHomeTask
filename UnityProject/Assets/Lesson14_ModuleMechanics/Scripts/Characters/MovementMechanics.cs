using Lessons.Lesson14_ModuleMechanics;
using UnityEngine;

namespace Assets.Lesson14_ModuleMechanics.Scripts
{
    public class MovementMechanics
    {
        private AtomicVariable<float> _speed;
        private AtomicVariable<Vector3> _moveDirection;
        private AtomicVariable<bool> _canMove;
        private Transform _target;

        public MovementMechanics(AtomicVariable<float> speed, AtomicVariable<Vector3> moveDirection, Transform target, AtomicVariable<bool> canMove)
        {
            _speed = speed;
            _moveDirection = moveDirection;
            _target = target;
            _canMove = canMove;
        }

        public void Update()
        {
            if (!_canMove.Value)
            {
                return;
            }

            _target.position += _moveDirection.Value * _speed.Value * Time.deltaTime;
        }
    }
}