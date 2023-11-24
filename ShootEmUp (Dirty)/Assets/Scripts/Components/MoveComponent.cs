using Assets.Scripts.Common;
using UnityEngine;

namespace Assets.Scripts.Components
{
    public sealed class MoveComponent : MonoBehaviour
    {
        [SerializeField]
        private new Rigidbody2D _rigidbody2D;

        private const float Speed = 5f;

        public void MoveByRigidbodyVelocity(Vector2 vector)
        {
            var nextPosition = _rigidbody2D.position + vector * Speed;
            _rigidbody2D.MovePosition(nextPosition);
        }
    }
}