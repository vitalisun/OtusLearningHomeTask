using Assets.Game.Scripts.Shared;

namespace Assets.Game.Scripts.Player.Mechanics
{
    public class RestoreBulletsOverTimeMechanics
    {
        private readonly AtomicVariable<int> _bulletAmount;
        private float _restoreTime = 2f;

        public RestoreBulletsOverTimeMechanics(AtomicVariable<int> bulletAmount)
        {
            _bulletAmount = bulletAmount;
        }

        public void Update(float deltaTime)
        {
            _restoreTime -= deltaTime;
            if (_restoreTime <= 0 && _bulletAmount.Value < 10)
            {
                _bulletAmount.Value += 1;
                _restoreTime = 2f;
            }
        }
    }
}