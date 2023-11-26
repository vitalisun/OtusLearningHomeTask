using Assets.Scripts.Bullets;
using Assets.Scripts.Components;
using Assets.Scripts.GameManager;
using Assets.Scripts.Input;
using UnityEngine;

namespace Assets.Scripts.Character
{
    public sealed class CharacterController : MonoBehaviour,
        IInstaller,
        Listeners.IGameStartListener,
        Listeners.IGameFinishListener,
        Listeners.IGamePauseListener,
        Listeners.IGameResumeListener,
        Listeners.IGameFixedUpdateListener
    {
        [SerializeField] private GameObject _character;
        private IInputManager _inputManager;
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

        public void Construct(IInputManager inputManager)
        {
            Debug.Log($"inputManager.GetType().Name - {inputManager.GetType().Name})");
            _inputManager = inputManager;
        }   

        public void Install()
        {
            _hitPointsComponent = _character.GetComponent<HitPointsComponent>();
            _moveComponent = _character.GetComponent<MoveComponent>();
            _weaponComponent = _character.GetComponent<WeaponComponent>();
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
            _character.transform.position = new Vector3(0, _character.transform.position.y, 0);
        }


        public void OnPause()
        {
            enabled = false;
        }

        public void OnResume()
        {
            enabled = true;
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