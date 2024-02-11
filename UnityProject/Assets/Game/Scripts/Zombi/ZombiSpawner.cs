using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.Game.Scripts.GameManager;
using UnityEngine;

namespace Assets.Game.Scripts.Zombi
{
    [RequireComponent(typeof(GameManager.GameManager))]
    public class ZombiSpawner : MonoBehaviour,
        Listeners.IGameFinishListener
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
        private HashSet<Zombi> _zombiSet = new HashSet<Zombi>();
        private GameManager.GameManager _gameManager;

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

            _gameManager = GetComponent<GameManager.GameManager>();
        }

        private void Update()
        {
            if (_gameManager.State != GameState.PLAYING)
            {
                return;
            }

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

            _zombiSet.Add(zombi);
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

            _zombiSet.Remove(zombi);
        }

        public void OnFinish()
        {
            var zombiList = _zombiSet.ToList();

            foreach (var zombi in zombiList)
            {
                zombi.DeathEvent.Unsubscribe(ReturnToPool);
                _zombiPool.ReturnZombiToPool(zombi, _zombiContainer);

                _zombiSet.Remove(zombi);
            }
        }
    }
}
