using Assets.Game.Scripts.Shared;
using UnityEngine;

namespace Assets.Game.Scripts.Bullet.Mechanics
{
    public class BulletCollisionMechanics
    {
        private readonly AtomicEvent<Bullet> _unspawnRequest;
        private readonly Bullet _bullet;

        public BulletCollisionMechanics(AtomicEvent<Bullet> unspawnRequest, Bullet bullet)
        {
            _unspawnRequest = unspawnRequest;
            _bullet = bullet;
        }

        public void OnTriggerEnter(Collider other)
        {
            _unspawnRequest.Invoke(_bullet);

            if (other.gameObject.CompareTag("Enemy"))
            {
                var zombi = other.gameObject.GetComponent<Zombi.Zombi>();
                zombi.TakeDamageEvent.Invoke(1);
            }
        }
    }
}