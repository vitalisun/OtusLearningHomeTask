using System.Collections.Generic;
using Assets.Scripts.Bullets;
using Assets.Scripts.CharacterFiles;
using Assets.Scripts.Common;
using Assets.Scripts.Components;
using Assets.Scripts.EnemyFiles.Agents;
using Assets.Scripts.GameManager.DI;
using Assets.Scripts.GameManager.GameSystem.Interfaces;
using UnityEngine;

namespace Assets.Scripts.EnemyFiles
{
    public sealed class EnemyManager :
        IInstaller,
        Listeners.IGameFinishListener,
        Listeners.IGameUpdateListener
    {
        public int SpawnInterval = 1;
        public BulletConfig BulletConfig { get; set; }

        private EnemyPool _enemyPool;

        private BulletSystem _bulletSystem;
        private EnemyPositions _enemyPositions;
        private GameObject _character;
        private Transform _worldContainer;
        private Transform _enemyPoolContainer;
        private Enemy _enemyPrefab;
        private GameManager.GameSystem.GameManager _gameManager;


        private readonly HashSet<GameObject> _activeEnemies = new();

        private float _timeSinceLastSpawn;

        [Inject]
        public void Construct(
            BulletSystem bulletSystem,
            EnemyPositions enemyPositions,
            Character character,
            WorldContainer worldContainer,
            EnemyPoolContainer enemyPoolContainer,
            Enemy enemyPrefab,
            GameManager.GameSystem.GameManager gameManager
        )
        {
            _bulletSystem = bulletSystem;
            _enemyPositions = enemyPositions;
            _character = character.gameObject;
            _worldContainer = worldContainer.transform;
            _enemyPoolContainer = enemyPoolContainer.transform;
            _enemyPrefab = enemyPrefab;
            _gameManager = gameManager;
        }

        public void Install()
        {
            _enemyPool = new EnemyPool(_enemyPositions, _character, _worldContainer, _enemyPoolContainer);
            _enemyPool.InitPool(_enemyPrefab.gameObject, _gameManager);
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
                PhysicsLayer = (int)BulletConfig.PhysicsLayer,
                Color = BulletConfig.Color,
                Damage = BulletConfig.Damage,
                Position = position,
                Velocity = direction * BulletConfig.Speed
            });
        }

        public void OnFinish()
        {
            var cache = new List<GameObject>(_activeEnemies);

            foreach (var enemy in cache)
            {
                RemoveEnemy(enemy);
            }
        }


    }
}