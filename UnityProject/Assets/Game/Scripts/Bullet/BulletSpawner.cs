using UnityEngine;

namespace Assets.Game.Scripts.Bullet
{
    public class BulletSpawner : MonoBehaviour
    {
        [SerializeField] private Player.Player _player;
        [SerializeField] private Bullet _bulletPrefab;
        [SerializeField] private Transform _bulletSpawnPoint;
        [SerializeField] private Transform _bulletContainer;
        [SerializeField] private Transform _worldTransform;

        private BulletPool _bulletPool;

        private void Awake()
        {
            _bulletPool = new BulletPool(10);
            _bulletPool.InitPool(_bulletPrefab, _bulletContainer);

            _player.FireEvent.Subscribe(SpawnBullet);
        }

        private void SpawnBullet()
        {
            var bullet = _bulletPool.GetBulletFromPool(_bulletPrefab, _bulletSpawnPoint, _worldTransform);
            bullet.MoveDirection.Value = _bulletSpawnPoint.forward;
            bullet.UnspawnRequest.Subscribe(ReturnToPool);
        }

        private void ReturnToPool(Bullet bullet)
        {
            bullet.UnspawnRequest.Unsubscribe(ReturnToPool);
            _bulletPool.ReturnBulletToPool(bullet, _bulletContainer);
        }

        private void OnDestroy()
        {
            _player.FireEvent.Unsubscribe(SpawnBullet);
        }
    }
}
