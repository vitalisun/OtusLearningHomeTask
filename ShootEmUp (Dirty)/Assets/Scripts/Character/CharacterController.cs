using System;
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

        void Awake()
        {
            _hitPointsComponent = _character.GetComponent<HitPointsComponent>();
            _moveComponent = _character.GetComponent<MoveComponent>();
            _weaponComponent = _character.GetComponent<WeaponComponent>();
        }

        private void OnEnable()
        {
            _hitPointsComponent.hpEmpty += OnCharacterDeath;
        }

        private void OnDisable()
        {
            _hitPointsComponent.hpEmpty -= OnCharacterDeath;
        }

        private void FixedUpdate()
        {
            _moveComponent.MoveByRigidbodyVelocity(new Vector2(HorizontalDirection, 0) * Time.fixedDeltaTime);

            if (FireRequired)
            {
                OnFlyBullet();
                FireRequired = false;
            }
        }

        private void OnCharacterDeath(GameObject _) => _gameManager.FinishGame();

        private void OnFlyBullet()
        {
            _bulletSystem.FlyBulletByArgs(new BulletSystem.Args
            {
                isPlayer = true,
                physicsLayer = (int) _bulletConfig.physicsLayer,
                color = _bulletConfig.color,
                damage = _bulletConfig.damage,
                position = _weaponComponent.Position,
                velocity = _weaponComponent.Rotation * Vector3.up * _bulletConfig.speed
            });
        }
    }
}