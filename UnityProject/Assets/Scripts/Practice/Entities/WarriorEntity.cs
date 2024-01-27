using Assets.Scripts.Practice.Components;
using UnityEngine;

namespace Assets.Scripts.Practice.Entities
{
    public class WarriorEntity : Entity
    {
        [SerializeField] private Warrior _warrior;

        private void Awake()
        {
            Add(new TakeDamageComponent(_warrior.TakeDamageEvent));
        }


        public void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Bullet bullet))
            {
                if (TryGetComponent(out TakeDamageComponent takeDamageComponent))
                {
                    takeDamageComponent.TakeDamage(bullet.Damage.Value);
                }

                Destroy(other.gameObject);
            }
        }
    }
}