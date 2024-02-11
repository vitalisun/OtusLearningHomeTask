using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Game.Scripts.Zombi
{
    public class ZombiSpawner : MonoBehaviour
    {
        [SerializeField] private float _spawnInterval;
        [SerializeField] private float _returnToPoolInterval;
        [SerializeField] private Zombi _zombiPrefab;
        [SerializeField] private Transform _zombiSpawnRoot;
        [SerializeField] private Transform _zombiContainer;
        [SerializeField] private Transform _worldTransform;
        [SerializeField] private GameObject target;

        private ZombiPool _zombiPool;
        private List<Transform> _zombiSpawnPoints;

        private void Awake()
        {
            _spawnInterval = 2;
            _returnToPoolInterval = 2;
            _zombiPool = new ZombiPool(10);
            _zombiPrefab.Target.Value = target.transform;
            _zombiPool.InitPool(_zombiPrefab, _zombiContainer);

            _zombiSpawnPoints = _zombiSpawnRoot.GetComponentsInChildren<Transform>()
                .Where(x => x != _zombiSpawnRoot)
                .ToList();
        }

        private void Update()
        {
            _spawnInterval -= Time.deltaTime;
            if (_spawnInterval <= 0)
            {
                _spawnInterval = 2;
                SpawnZombi();
            }
        }

        private void SpawnZombi()
        {
            var randomSpawnPoint = _zombiSpawnPoints[UnityEngine.Random.Range(0, _zombiSpawnPoints.Count)];

            var zombi = _zombiPool.GetZombiFromPool(_zombiPrefab, randomSpawnPoint, _worldTransform);
            zombi.State.Value = ZombiStates.Follow;
            zombi.DeathEvent.Subscribe(ReturnToPool);
            zombi.Target.Value = target.transform;
        }

        private void ReturnToPool(Zombi zombi)
        {
            StartCoroutine(ReturnToPoolAfterDelay(zombi, _returnToPoolInterval));
        }

        private IEnumerator ReturnToPoolAfterDelay(Zombi zombi, float delayInSeconds)
        {
            yield return new WaitForSeconds(delayInSeconds);

            zombi.DeathEvent.Unsubscribe(ReturnToPool);
            _zombiPool.ReturnZombiToPool(zombi, _zombiContainer);
        }
    }
}
