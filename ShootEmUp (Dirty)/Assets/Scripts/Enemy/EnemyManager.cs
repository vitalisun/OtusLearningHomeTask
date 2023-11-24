using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Bullets;
using Assets.Scripts.Components;
using Assets.Scripts.Enemy.Agents;
using Assets.Scripts.GameManager;
using UnityEngine;

namespace Assets.Scripts.Enemy
{
    public sealed class EnemyManager : MonoBehaviour,
        Listeners.IGamePauseListener,
        Listeners.IGameResumeListener,
        Listeners.IGameFinishListener,
        Listeners.IGameStartListener,
        Listeners.IGameUpdateListener
    {
        public int SpawnInterval = 1;

        [SerializeField]
        private EnemyPool _enemyPool;

        [SerializeField]
        private BulletSystem _bulletSystem;

        [SerializeField]
        private BulletConfig _bulletConfig;

        private readonly HashSet<GameObject> _activeEnemies = new();

        private float _timeSinceLastSpawn;

        private void Awake()
        {
            enabled = false;
        }

        public void OnUpdate(float deltaTime)
        {
            SpawnInLoop();
        }

        private void SpawnInLoop()
        {
            _timeSinceLastSpawn += Time.deltaTime;

            if (_timeSinceLastSpawn < SpawnInterval)
                return;

            _timeSinceLastSpawn = 0;

            if (_enemyPool.SpawnEnemy(out var enemy))
            {
                if (_activeEnemies.Add(enemy))
                {
                    enemy.GetComponent<HitPointsComponent>().OnDeath += RemoveEnemy;
                    enemy.GetComponent<EnemyAttackAgent>().OnFire += OnFire;
                }
            }
        }

        private void RemoveEnemy(GameObject enemy)
        {
            if (_activeEnemies.Remove(enemy))
            {
                enemy.GetComponent<HitPointsComponent>().OnDeath -= RemoveEnemy;
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

        public void OnPause()
        {
            enabled = false;
        }

        public void OnResume()
        {
           enabled = true;
        }

        public void OnFinish()
        {
            var cache = new List<GameObject>(_activeEnemies);

            foreach (var enemy in cache)
            {
                RemoveEnemy(enemy);
            }

            enabled = false;
        }

        public void OnStart()
        {
            enabled = true;
        }
    }
}