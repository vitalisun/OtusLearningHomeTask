using Assets.Scripts.Components;
using System;
using UnityEngine;

namespace Assets.Scripts.Enemy.Agents
{
    public sealed class EnemyAttackAgent : MonoBehaviour
    {
        public event Action<GameObject, Vector2, Vector2> OnFire;

        [SerializeField] private WeaponComponent _weaponComponent;
        [SerializeField] private EnemyMoveAgent _moveAgent;
        [SerializeField] private float _countdown;

        private GameObject _target;
        private float _currentTime;

        public void SetTarget(GameObject target)
        {
            this._target = target;
        }

        public void Reset()
        {
            _currentTime = _countdown;
        }

        private void FixedUpdate()
        {
            if (!_moveAgent.IsReached)
            {
                return;
            }

            if (_target.TryGetComponent(out HitPointsComponent hitPointsComponent))
            {
                if (!hitPointsComponent.IsHitPointsExists())
                {
                    return;
                }
            }

            _currentTime -= Time.fixedDeltaTime;
            if (_currentTime <= 0)
            {
                Fire();
                _currentTime += _countdown;
            }
        }

        private void Fire()
        {
            var startPosition = _weaponComponent.Position;
            var vector = (Vector2)_target.transform.position - startPosition;
            var direction = vector.normalized;
            OnFire?.Invoke(gameObject, startPosition, direction);
        }
    }
}