using Assets.Scripts.Bullets;
using Assets.Scripts.Components;
using Assets.Scripts.GameManager.DI;
using Assets.Scripts.GameManager.GameSystem.Interfaces;
using Assets.Scripts.Input;
using UnityEngine;

namespace Assets.Scripts.CharacterFiles
{
    public sealed class CharacterController :
        IInstaller,
        Listeners.IGameStartListener,
        Listeners.IGameFinishListener,
        Listeners.IGamePauseListener,
        Listeners.IGameResumeListener,
        Listeners.IGameFixedUpdateListener
    {
        [HideInInspector]
        public bool FireRequired;
        [HideInInspector]
        public float HorizontalDirection;

        private MoveComponent _moveComponent;
        private HitPointsComponent _hitPointsComponent;
        private WeaponComponent _weaponComponent;

        private IInputManager _inputManager;
        private BulletSystem _bulletSystem;
        private BulletConfig _bulletConfig;
        private Character _characterScript;
        private GameManager.GameSystem.GameManager _gameManager;

        [Inject]
        public void Construct(
            IInputManager inputManager,
            BulletSystem bulletSystem,
            BulletConfig bulletConfig,
            Character characterScript,
            GameManager.GameSystem.GameManager gameManager
            )
        {
            _inputManager = inputManager;
            _bulletSystem = bulletSystem;
            _bulletConfig = bulletConfig;
            _characterScript = characterScript;
            _gameManager = gameManager;
        }

        public void Install()
        {
            _hitPointsComponent = _characterScript.GetComponent<HitPointsComponent>();
            _moveComponent = _characterScript.GetComponent<MoveComponent>();
            _weaponComponent = _characterScript.GetComponent<WeaponComponent>();
        }


        public void OnStart()
        {
            _hitPointsComponent.OnDeath += OnCharacterDeath;
            _inputManager.OnMoveEvent += OnMoveEventHandler;
            _inputManager.OnFireEvent += OnFireEventHandler;
        }

        public void OnFinish()
        {
            _hitPointsComponent.OnDeath -= OnCharacterDeath;
            _inputManager.OnMoveEvent -= OnMoveEventHandler;
            _inputManager.OnFireEvent -= OnFireEventHandler;


            ResetCharacterState();
        }

        private void ResetCharacterState()
        {
            _hitPointsComponent.ResetHitPoints();
            _characterScript.transform.position = new Vector3(0, _characterScript.transform.position.y, 0);
        }


        public void OnPause()
        {
        }

        public void OnResume()
        {
        }

        public void OnFixedUpdate(float deltaTime)
        {
            _moveComponent.MoveByRigidbodyVelocity(new Vector2(HorizontalDirection, 0) * Time.fixedDeltaTime);

            Fire();
        }

        private void OnCharacterDeath(GameObject _)
        {
            _gameManager.Finish();
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

        private void OnMoveEventHandler(float directionValue)
        {
            HorizontalDirection = directionValue;
        }

        private void OnFireEventHandler(bool value)
        {
            FireRequired = value;
        }
    }
}