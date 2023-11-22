using Assets.Scripts.Bullets;
using Assets.Scripts.Components;
using Assets.Scripts.Input;
using UnityEngine;

namespace Assets.Scripts.Character
{
    public sealed class CharacterController : MonoBehaviour
    {
        [SerializeField] private GameObject _character;
        [SerializeField] private InputManager _inputManager;
        [SerializeField] private GameManager.GameManager _gameManager;
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
            _hitPointsComponent.OnDeath += OnCharacterDeath;
            _inputManager.OnMoveEvent += UpdateHorisontalDirection;
        }
        private void OnDisable()
        {
            _hitPointsComponent.OnDeath -= OnCharacterDeath;
            _inputManager.OnMoveEvent -= UpdateHorisontalDirection;
        }

        private void FixedUpdate()
        {
            _moveComponent.MoveByRigidbodyVelocity(new Vector2(HorizontalDirection, 0) * Time.fixedDeltaTime);

            Fire();
        }

        private void OnCharacterDeath(GameObject _)
        {
            _gameManager.FinishGame();
        }

        private void Fire()
        {
            if (!FireRequired) 
                return;

            _bulletSystem.FireBullet(new BulletArgs
            {
                IsPlayer = true,
                PhysicsLayer = (int)_bulletConfig.PhysicsLayer,
                Color = _bulletConfig.Color,
                Damage = _bulletConfig.Damage,
                Position = _weaponComponent.Position,
                Velocity = _weaponComponent.Rotation * Vector3.up * _bulletConfig.Speed
            });

            FireRequired = false;
        }

        private void UpdateHorisontalDirection(float directionValue)
        {
            HorizontalDirection = directionValue;
        }
    }
}