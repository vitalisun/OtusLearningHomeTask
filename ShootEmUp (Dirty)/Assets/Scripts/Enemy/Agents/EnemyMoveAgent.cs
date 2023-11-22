using Assets.Scripts.Common;
using Assets.Scripts.Components;
using UnityEngine;

namespace Assets.Scripts.Enemy.Agents
{
    public sealed class EnemyMoveAgent : MonoBehaviour
    {
        public bool IsReached
        {
            get { return _isReached; }
        }

        [SerializeField] 
        private MoveComponent _moveComponent;

        [SerializeField]
        private const float ReachDistanseThreshold = 0.25f;

        private Vector2 _destination;

        private bool _isReached;

        public void SetDestination(Vector2 endPoint)
        {
            _destination = endPoint;
            _isReached = false;
        }

        private void FixedUpdate()
        {
            if (_isReached)
            {
                return;
            }

            var vector = _destination - (Vector2)transform.position;
            if (vector.magnitude <= ReachDistanseThreshold)
            {
                _isReached = true;
                return;
            }

            var direction = vector.normalized * Time.fixedDeltaTime;
            _moveComponent.MoveByRigidbodyVelocity(direction);
        }
    }
}