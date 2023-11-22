using UnityEngine;

namespace ShootEmUp
{
    public sealed class CharacterController : MonoBehaviour
    {
        [SerializeField] private GameObject _character;
        [SerializeField] private GameManager _gameManager;
        [SerializeField] private BulletSystem _bulletSystem;
        [SerializeField] private BulletConfig _bulletConfig;

        [HideInInspector]
        public bool FireRequired;
        [HideInInspector]
        public float HorizontalDirection;

        private MoveComponent _moveComponent;
        private HitPointsComponent _hitPointsComponent;
        private WeaponComponent _weaponComponent;

        private void Awake()
        {
            _hitPointsComponent = _character.GetComponent<HitPointsComponent>();
            _moveComponent = _character.GetComponent<MoveComponent>();
            _weaponComponent = _character.GetComponent<WeaponComponent>();
        }

        private void OnEnable()
        {
            _hitPointsComponent.HpEmpty += OnCharacterDeath;
        }

        private void OnDisable()
        {
            _hitPointsComponent.HpEmpty -= OnCharacterDeath;
        }

        private void FixedUpdate()
        {
            _moveComponent.MoveByRigidbodyVelocity(new Vector2(HorizontalDirection, 0) * Time.fixedDeltaTime);

            if (FireRequired)
            {
                OnFireBullet();
                FireRequired = false;
            }
        }

        private void OnCharacterDeath(GameObject _) => _gameManager.FinishGame();

        private void OnFireBullet()
        {
            _bulletSystem.FireBullet(new BulletArgs
            {
                IsPlayer = true,
                PhysicsLayer = (int)_bulletConfig.PhysicsLayer,
                Color = _bulletConfig.Color,
                Damage = _bulletConfig.Damage,
                Position = _weaponComponent.Position,
                Velocity = _weaponComponent.Rotation * Vector3.up * _bulletConfig.Speed
            });
        }
    }
}