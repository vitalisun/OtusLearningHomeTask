using Assets.Scripts.Practice.Mechanics;
using Assets.Scripts.Shared;
using UnityEngine;

namespace Assets.Scripts.Practice
{
    public class Warrior : MonoBehaviour
    {
        // data
        public AtomicVariable<int> Health = new();
        public AtomicEvent<int> TakeDamageEvent = new();
        public AtomicEvent DeathRequest = new();
        public AtomicVariable<bool> IsDead = new();


        // logic
        private TakeDamageMechanic _takeDamageMechanic;
        private DeathMechanics _deathMechanic;

        private void Awake()
        {
            Health.Value = 10;
            _takeDamageMechanic = new TakeDamageMechanic(Health, TakeDamageEvent, DeathRequest, IsDead);
            _deathMechanic = new DeathMechanics(DeathRequest, gameObject);
        }

        private void OnEnable()
        {
            _takeDamageMechanic.OnEnable();
            _deathMechanic.OnEnable();
        }

        private void OnDisable()
        {
            _takeDamageMechanic.OnDisable();
            _deathMechanic.OnDisable();
        }
    }
}