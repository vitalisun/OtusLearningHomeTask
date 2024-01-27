using Assets.Scripts.Practice.Mechanics;
using Assets.Scripts.Shared;
using UnityEngine;

namespace Assets.Scripts.Practice
{
    public class Bullet : MonoBehaviour
    {
        // data
        public AtomicVariable<Vector3> MovementDirection = new();
        public AtomicVariable<float> MovementSpeed = new();
        public AtomicVariable<int> Damage = new();

        // logic
        private MovementMechanics _movementMechanics;

        private void Awake()
        {
            MovementDirection.Value = Vector3.forward;
            MovementSpeed.Value = 5f;
            Damage.Value = 4;

            _movementMechanics = new MovementMechanics(MovementDirection, MovementSpeed, transform);
        }

        private void Update()
        {
            _movementMechanics.Update(Time.deltaTime);
        }
    }

  
}
