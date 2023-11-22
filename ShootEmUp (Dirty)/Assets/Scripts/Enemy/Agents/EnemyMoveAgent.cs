using Assets.Scripts.Common;
using Assets.Scripts.Components;
using UnityEngine;

namespace Assets.Scripts.Enemy.Agents
{
    public sealed class EnemyMoveAgent : MonoBehaviour
    {
        public bool IsReached { get; private set; }

        [SerializeField] 
        private MoveComponent _moveComponent;

        [SerializeField]
        private const float ReachDistanseThreshold = 0.25f;

        private Vector2 _destination;

        public void SetDestination(Vector2 endPoint)
        {
            _destination = endPoint;
            IsReached = false;
        }

        private void FixedUpdate()
        {
            if (IsReached)
            {
                return;
            }

            var vector = _destination - (Vector2)transform.position;
            if (vector.magnitude <= ReachDistanseThreshold)
            {
                IsReached = true;
                return;
            }

            var direction = vector.normalized * Time.fixedDeltaTime;
            _moveComponent.MoveByRigidbodyVelocity(direction);
        }
    }
}