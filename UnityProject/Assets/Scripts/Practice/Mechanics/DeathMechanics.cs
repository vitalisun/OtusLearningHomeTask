using Assets.Scripts.Shared;
using UnityEngine;

namespace Assets.Scripts.Practice.Mechanics
{
    public class DeathMechanics
    {
        private readonly AtomicEvent _deathRequest;
        private readonly GameObject _gameObject;

        public DeathMechanics(AtomicEvent deathRequest, GameObject gameObject)
        {
            _deathRequest = deathRequest;
            _gameObject = gameObject;
        }

        public void OnEnable()
        {
            _deathRequest.Subscribe(OnDeath);
        }

        public void OnDisable()
        {
            _deathRequest.Unsubscribe(OnDeath);
        }

        private void OnDeath()
        {
            Object.Destroy(_gameObject);
        }
    }
}