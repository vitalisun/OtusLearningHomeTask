using Assets.Scripts.Practice.Mechanics;
using Assets.Scripts.Shared;
using UnityEngine;

namespace Assets.Scripts.Practice
{
    public class Tower : MonoBehaviour
    {
        [SerializeField]
        private Transform _spawnPoint;
        [SerializeField]
        private GameObject _bulletPrefab;

        // data
        public AtomicEvent FireRequest = new();

        // logic
        private SpawnBulletMechanics _spawnBulletMechanics;

        private void Awake()
        {
            _spawnBulletMechanics = new SpawnBulletMechanics(_spawnPoint, _bulletPrefab, FireRequest);
        }

        private void OnEnable()
        {
            _spawnBulletMechanics.OnEnable();
        }

        private void OnDisable()
        {
            _spawnBulletMechanics.OnDisable();
        }
    }
}