using System.Collections.Generic;
using Assets.Scripts.Common;
using Assets.Scripts.Enemy.Agents;
using Assets.Scripts.GameManager;
using UnityEngine;

namespace Assets.Scripts.Enemy
{
    public sealed class EnemyPool : MonoBehaviour,
        IInstaller
    {
        [Header("Spawn")]
        [SerializeField]
        private EnemyPositions _enemyPositions;

        [SerializeField]
        private GameObject _character;

        [SerializeField]
        private Transform _worldTransform;

        [Header("Pool")]
        [SerializeField]
        private Transform _container;

        [SerializeField]
        private GameObject _prefab;

        private const int EnemyPoolInitialCount = 7;

        private readonly Queue<GameObject> _enemyPool = new();

        public void Install()
        {
            for (var i = 0; i < EnemyPoolInitialCount; i++)
            {
                var enemy = Instantiate(_prefab, _container);
                _enemyPool.Enqueue(enemy);
            }
        }

        public bool SpawnEnemy(out GameObject enemy)
        {
            if (!_enemyPool.TryDequeue(out enemy))
            {
                return false;
            }

            enemy.transform.SetParent(_worldTransform);
            var spawnPosition = _enemyPositions.RandomSpawnPosition();
            enemy.transform.position = spawnPosition.position;
            var attackPosition = _enemyPositions.RandomAttackPosition();

            if (enemy.TryGetComponent<EnemyMoveAgent>(out var enemyMoveAgent))
            {
                enemyMoveAgent.SetDestination(attackPosition.position);
            }
            else
            {
                Debug.LogError("EnemyAttackAgent not found");
            }

            if (enemy.TryGetComponent<EnemyAttackAgent>(out var enemyAttackAgent))
            {
                enemyAttackAgent.SetTarget(_character);
            }
            else
            {
                Debug.LogError("HitPointsComponent not found");
            }

            return true;
        }

        public void UnspawnEnemy(GameObject enemy)
        {
            enemy.transform.SetParent(_container);
            _enemyPool.Enqueue(enemy);
        }
    }
}