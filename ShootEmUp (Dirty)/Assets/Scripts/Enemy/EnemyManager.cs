using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class EnemyManager : MonoBehaviour
    {
        [SerializeField]
        private EnemyPool _enemyPool;

        [SerializeField]
        private BulletSystem _bulletSystem;
        [SerializeField]
        private BulletConfig _bulletConfig;

        private readonly HashSet<GameObject> _activeEnemies = new();

        private void Start()
        {
            StartCoroutine(EnemySpawnCycle());
        }

        private IEnumerator EnemySpawnCycle()
        {
            while (true)
            {
                yield return new WaitForSeconds(1);
                var enemy = _enemyPool.SpawnEnemy();
                if (enemy != null)
                {
                    if (_activeEnemies.Add(enemy))
                    {
                        enemy.GetComponent<HitPointsComponent>().HpEmpty += OnDestroyed;
                        enemy.GetComponent<EnemyAttackAgent>().OnFire += OnFire;
                    }
                }
            }
        }

        private void OnDestroyed(GameObject enemy)
        {
            if (_activeEnemies.Remove(enemy))
            {
                enemy.GetComponent<HitPointsComponent>().HpEmpty -= OnDestroyed;
                enemy.GetComponent<EnemyAttackAgent>().OnFire -= OnFire;

                _enemyPool.UnspawnEnemy(enemy);
            }
        }

        private void OnFire(GameObject enemy, Vector2 position, Vector2 direction)
        {
            _bulletSystem.FireBullet(new BulletArgs
            {
                IsPlayer = false,
                PhysicsLayer = (int)_bulletConfig.PhysicsLayer,
                Color = _bulletConfig.Color,
                Damage = _bulletConfig.Damage,
                Position = position,
                Velocity = direction * _bulletConfig.Speed
            });
        }
    }
}