using UnityEngine;

namespace ShootEmUp
{
    public sealed class CharacterController : MonoBehaviour
    {
        [SerializeField] private GameObject character;
        [SerializeField] private GameManager gameManager;
        [SerializeField] private BulletSystem bulletSystem;
        [SerializeField] private BulletConfig bulletConfig;

        [HideInInspector]
        public bool FireRequired;
        [HideInInspector]
        public float HorizontalDirection;

        private MoveComponent moveComponent;
        private HitPointsComponent hitPointsComponent;
        private WeaponComponent weaponComponent;

        private void Awake()
        {
            hitPointsComponent = character.GetComponent<HitPointsComponent>();
            moveComponent = character.GetComponent<MoveComponent>();
            weaponComponent = character.GetComponent<WeaponComponent>();
        }

        private void OnEnable()
        {
            hitPointsComponent.hpEmpty += OnCharacterDeath;
        }

        private void OnDisable()
        {
            hitPointsComponent.hpEmpty -= OnCharacterDeath;
        }

        private void FixedUpdate()
        {
            moveComponent.MoveByRigidbodyVelocity(new Vector2(HorizontalDirection, 0) * Time.fixedDeltaTime);

            if (FireRequired)
            {
                OnFireBullet();
                FireRequired = false;
            }
        }

        private void OnCharacterDeath(GameObject _) => gameManager.FinishGame();

        private void OnFireBullet()
        {
            bulletSystem.FireBullet(new BulletArgs
            {
                isPlayer = true,
                physicsLayer = (int)bulletConfig.physicsLayer,
                color = bulletConfig.color,
                damage = bulletConfig.damage,
                position = weaponComponent.Position,
                velocity = weaponComponent.Rotation * Vector3.up * bulletConfig.speed
            });
        }
    }
}