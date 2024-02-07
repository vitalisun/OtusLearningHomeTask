using Assets.Game.Scripts.Shared;
using UnityEngine;

namespace Assets.Game.Scripts.Player.Mechanics
{
    public class RestoreBulletsOverTimeMechanics
    {
        private AtomicVariable<int> _bulletAmount;
        private float _restoreTime = 2f;

        public RestoreBulletsOverTimeMechanics(AtomicVariable<int> bulletAmount)
        {
            _bulletAmount = bulletAmount;
        }

        public void Update(float deltaTime)
        {
            _restoreTime -= deltaTime;
            if (_restoreTime <= 0)
            {
                _bulletAmount.Value += 1;
                _restoreTime = 2f;

                Debug.Log("Bullet amount: " + _bulletAmount.Value);
            }
        }
    }
}