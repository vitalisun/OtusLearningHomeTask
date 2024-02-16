using UnityEngine;
using Zenject;

namespace Assets.Game.Scripts.Bullet
{
    public class BulletSpawner : MonoBehaviour
    {
        [SerializeField] private Transform _bulletSpawnPoint;
        [SerializeField] private Transform _bulletContainer;
        [SerializeField] private Transform _worldTransform;

        private Player.Player _player;
        private Bullet _bulletPrefab;
        private BulletPool _bulletPool;

        [Inject]
        public void Construct(Player.Player player, Bullet bulletPrefab, BulletPool bulletPool)
        {
            _player = player;
            _bulletPrefab = bulletPrefab;
            _bulletPool = bulletPool;
        }

        private void Awake()
        {
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
