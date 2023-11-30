using System.Collections.Generic;
using Assets.Scripts.EnemyFiles.Agents;
using UnityEngine;

namespace Assets.Scripts.EnemyFiles
{
    public sealed class EnemyPool
    {
        private const int EnemyPoolInitialCount = 7;
        private readonly Queue<GameObject> _enemyPool = new();

        private EnemyPositions _enemyPositions;
        private GameObject _character;
        private Transform _worldTransform;
        private Transform _container;

        public EnemyPool(
            EnemyPositions enemyPositions, 
            GameObject character, 
            Transform worldTransform, 
            Transform container)
        {
            _enemyPositions = enemyPositions;
            _character = character;
            _worldTransform = worldTransform;
            _container = container;
        }

        public void InitPool(GameObject prefab, GameManager.GameSystem.GameManager gameManager)
        {
            for (var i = 0; i < EnemyPoolInitialCount; i++)
            {
                var enemy = Object.Instantiate(prefab, _container);
                _enemyPool.Enqueue(enemy);

                gameManager.AddListener(enemy.GetComponent<EnemyMoveAgent>());
                gameManager.AddListener(enemy.GetComponent<EnemyAttackAgent>());
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