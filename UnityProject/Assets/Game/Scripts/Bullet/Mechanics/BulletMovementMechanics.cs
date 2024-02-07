using Assets.Game.Scripts.Shared;
using UnityEngine;

namespace Assets.Game.Scripts.Bullet.Mechanics
{
    public class BulletMovementMechanics
    {
        private readonly AtomicVariable<float> _speed;
        private readonly AtomicVariable<Vector3> _moveDirection;
        private readonly Transform _transform;
        private readonly AtomicVariable<bool> _canMove;

        public BulletMovementMechanics(AtomicVariable<float> speed, AtomicVariable<Vector3> moveDirection, Transform transform, AtomicVariable<bool> canMove)
        {
            _speed = speed;
            _moveDirection = moveDirection;
            _transform = transform;
            _canMove = canMove;
        }

        public void Update(float deltaTime)
        {
            if (!_canMove.Value)
            {
                return;
            }

            _transform.position += _moveDirection.Value * _speed.Value * deltaTime;
        }
    }
}
