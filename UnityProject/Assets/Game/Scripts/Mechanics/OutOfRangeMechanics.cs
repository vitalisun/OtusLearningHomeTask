using Assets.Scripts.Shared;
using UnityEngine;

namespace Assets.Game.Scripts.Mechanics
{
    public class OutOfRangeMechanics
    {
        private readonly AtomicVariable<Vector3> _startPosition;
        private readonly AtomicEvent<Bullet.Bullet> _unspawnRequest;
        private readonly Bullet.Bullet _bullet;

        public OutOfRangeMechanics(AtomicVariable<Vector3> startPosition, AtomicEvent<Bullet.Bullet> unspawnRequest, Bullet.Bullet bullet)
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