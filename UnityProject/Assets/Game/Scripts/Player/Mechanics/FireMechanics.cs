using Assets.Game.Scripts.Shared;

namespace Assets.Game.Scripts.Player.Mechanics
{
    public class FireMechanics
    {
        private readonly AtomicVariable<int> _bulletAmount;
        private readonly AtomicEvent _fireRequest;
        private readonly AtomicEvent _fireEvent;

        public FireMechanics(AtomicVariable<int> bulletAmount, AtomicEvent fireRequest, AtomicEvent fireEvent)
        {
            _bulletAmount = bulletAmount;
            _fireRequest = fireRequest;
            _fireEvent = fireEvent;
        }

        public void OnEnable()
        {
            _fireRequest.Subscribe(Fire);
        }

        public void OnDisable()
        {
            _fireRequest.Unsubscribe(Fire);
        }

        private void Fire()
        {
            if (_bulletAmount.Value > 0)
            {
                _bulletAmount.Value -= 1;
                _fireEvent.Invoke();
            }
        }
    }
}