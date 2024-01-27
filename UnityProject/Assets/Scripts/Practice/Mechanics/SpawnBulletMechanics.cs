using Assets.Scripts.Shared;
using UnityEngine;

namespace Assets.Scripts.Practice.Mechanics
{
    public class SpawnBulletMechanics
    {
        private readonly Transform _spawnPoint;
        private readonly GameObject _bulletPrefab;
        private readonly AtomicEvent _fireRequest;

        public SpawnBulletMechanics(Transform spawnPoint, GameObject bulletPrefab, AtomicEvent fireRequest)
        {
            _spawnPoint = spawnPoint;
            _bulletPrefab = bulletPrefab;
            _fireRequest = fireRequest;
        }

        public void OnEnable()
        {
            _fireRequest.Subscribe(SpawnBullet);
        }

        public void OnDisable()
        {
            _fireRequest.Unsubscribe(SpawnBullet);
        }

        private void SpawnBullet()
        {
            Object.Instantiate(_bulletPrefab, _spawnPoint.position, _spawnPoint.rotation);
        }

    }
}