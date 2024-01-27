using Assets.Scripts.Shared;

namespace Assets.Scripts.Practice.Components
{
    public class TakeDamageComponent
    {
        private readonly AtomicEvent<int> _takeDamageEvent;

        public TakeDamageComponent(AtomicEvent<int> takeDamageEvent)
        {
            _takeDamageEvent = takeDamageEvent;
        }

        public void TakeDamage(int damage)
        {
            _takeDamageEvent.Invoke(damage);
        }
    }
}