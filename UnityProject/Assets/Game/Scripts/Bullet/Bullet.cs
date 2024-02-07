using Assets.Game.Scripts.Bullet.Mechanics;
using Assets.Game.Scripts.Shared;
using UnityEngine;

namespace Assets.Game.Scripts.Bullet
{
    public class Bullet : MonoBehaviour
    {
        //data
        public AtomicVariable<float> Speed = new();
        public AtomicVariable<Vector3> MoveDirection = new();
        public AtomicVariable<bool> CanMove = new();

        public AtomicVariable<Vector3> StartPosition = new();
        public AtomicEvent<Bullet> UnspawnRequest = new();

        //logic
        private BulletMovementMechanics _movementMechanics;
        private OutOfRangeMechanics _outOfRangeMechanics;
        private BulletCollisionMechanics _collisionMechanics;

        public void Awake()
        {
            Speed.Value = 40;
            CanMove.Value = true;
            StartPosition.Value = transform.position;   

            _movementMechanics = new BulletMovementMechanics(Speed, MoveDirection, transform, CanMove);
            _outOfRangeMechanics = new OutOfRangeMechanics(StartPosition, UnspawnRequest, this);
            _collisionMechanics = new BulletCollisionMechanics(UnspawnRequest, this);
        }

        public void Update()
        {
            _movementMechanics.Update(Time.deltaTime);
            _outOfRangeMechanics.Update();
        }

        public void OnTriggerEnter(Collider other)
        {
            _collisionMechanics.OnTriggerEnter(other);
        }
    }
}