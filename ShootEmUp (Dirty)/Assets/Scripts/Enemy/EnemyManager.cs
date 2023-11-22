using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class EnemyManager : MonoBehaviour
    {
        [SerializeField]
        private EnemyPool enemyPool;

        [SerializeField]
        private BulletSystem bulletSystem;
        [SerializeField]
        private BulletConfig bulletConfig;

        private readonly HashSet<GameObject> activeEnemies = new();

        private void Start()
        {
            StartCoroutine(EnemySpawnCycle());
        }

        private IEnumerator EnemySpawnCycle()
        {
            while (true)
            {
                yield return new WaitForSeconds(1);
                var enemy = enemyPool.SpawnEnemy();
                if (enemy != null)
                {
                    if (activeEnemies.Add(enemy))
                    {
                        enemy.GetComponent<HitPointsComponent>().hpEmpty += OnDestroyed;
                        enemy.GetComponent<EnemyAttackAgent>().OnFire += OnFire;
                    }
                }
            }
        }

        private void OnDestroyed(GameObject enemy)
        {
            if (activeEnemies.Remove(enemy))
            {
                enemy.GetComponent<HitPointsComponent>().hpEmpty -= OnDestroyed;
                enemy.GetComponent<EnemyAttackAgent>().OnFire -= OnFire;

                enemyPool.UnspawnEnemy(enemy);
            }
        }

        private void OnFire(GameObject enemy, Vector2 position, Vector2 direction)
        {
            bulletSystem.FireBullet(new BulletArgs
            {
                isPlayer = false,
                physicsLayer = (int)bulletConfig.physicsLayer,
                color = bulletConfig.color,
                damage = bulletConfig.damage,
                position = position,
                velocity = direction * bulletConfig.speed
            });
        }
    }
}