using Assets.Scripts.Common;
using UnityEngine;

namespace Assets.Scripts.Components
{
    public sealed class MoveComponent : MonoBehaviour
    {
        [SerializeField]
        private new Rigidbody2D _rigidbody2D;

        [SerializeField]
        private float _speed = Consts.MoveComponentSpeed;

        public void MoveByRigidbodyVelocity(Vector2 vector)
        {
            var nextPosition = _rigidbody2D.position + vector * _speed;
            _rigidbody2D.MovePosition(nextPosition);
        }
    }
}