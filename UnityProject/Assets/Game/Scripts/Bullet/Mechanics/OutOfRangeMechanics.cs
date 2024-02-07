using Assets.Game.Scripts.Shared;
using UnityEngine;

namespace Assets.Game.Scripts.Bullet.Mechanics
{
    public class OutOfRangeMechanics
    {
        private readonly AtomicVariable<Vector3> _startPosition;
        private readonly AtomicEvent<Scripts.Bullet.Bullet> _unspawnRequest;
        private readonly Scripts.Bullet.Bullet _bullet;

        public OutOfRangeMechanics(AtomicVariable<Vector3> startPosition, AtomicEvent<Scripts.Bullet.Bullet> unspawnRequest, Scripts.Bullet.Bullet bullet)
        {
            _startPosition = startPosition;
            _unspawnRequest = unspawnRequest;
            _bullet = bullet;
        }

        public void Update()
        {
            if (Vector3.Distance(_startPosition.Value, _bullet.transform.position) > 100)
            {
                _unspawnRequest.Invoke(_bullet);
            }
        }
    }
}