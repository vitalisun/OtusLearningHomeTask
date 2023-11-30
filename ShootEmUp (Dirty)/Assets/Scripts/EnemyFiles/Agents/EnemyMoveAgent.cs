using Assets.Scripts.Components;
using Assets.Scripts.GameManager.GameSystem.Interfaces;
using UnityEngine;

namespace Assets.Scripts.EnemyFiles.Agents
{
    public sealed class EnemyMoveAgent : MonoBehaviour,
        Listeners.IGamePauseListener,
        Listeners.IGameResumeListener,
        Listeners.IGameFixedUpdateListener
    {
        public bool IsReached { get; private set; }

        [SerializeField]
        private MoveComponent _moveComponent;

        private const float ReachDistanseThreshold = 0.25f;

        private Vector2 _destination;

        public void SetDestination(Vector2 endPoint)
        {
            _destination = endPoint;
            IsReached = false;
        }

        public void OnFixedUpdate(float deltaTime)
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

        public void OnPause()
        {
            enabled = false;
        }

        public void OnResume()
        {
            enabled = true;
        }
    }
}