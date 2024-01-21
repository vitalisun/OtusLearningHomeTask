using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lessons.Lesson14_ModuleMechanics;
using UnityEngine;

namespace Assets.Lesson14_ModuleMechanics.Scripts
{
    public class Character : MonoBehaviour
    {
        //data
        public AtomicVariable<int> HitPoints;
        public AtomicEvent<int> TakeDamage;

        public AtomicVariable<bool> IsDead;
        public AtomicEvent Death;

        public AtomicVariable<float> Speed;
        public AtomicVariable<float> RotationSpeed;
        public AtomicVariable<Vector3> MoveDirection;
        public AtomicVariable<bool> CanMove;

        //logic
        private TakeDamageMechanics _takeDamageMechanics;
        private DeathMechanics _deathMechanics;
        private MovementMechanics _movementMechanics;
        private CanMoveMechanics _canMoveMechanics;
        private RotateMechanics _rotateMechanics;

        private void Awake()
        {
            _takeDamageMechanics = new TakeDamageMechanics(HitPoints, TakeDamage);
            _deathMechanics = new DeathMechanics(HitPoints, IsDead, Death);
            _movementMechanics = new MovementMechanics(Speed, MoveDirection, transform, CanMove);
            _canMoveMechanics = new CanMoveMechanics(CanMove, IsDead);
            _rotateMechanics = new RotateMechanics(MoveDirection, transform, CanMove, RotationSpeed);
        }

        private void Update()
        {
            _movementMechanics.Update();
            _canMoveMechanics.Update();
            _rotateMechanics.Update();
        }

        private void OnEnable()
        {
            _takeDamageMechanics.OnEnable();
            _deathMechanics.OnEnable();
        }

        private void OnDisable()
        {
            _takeDamageMechanics.OnDisable();
            _deathMechanics.OnDisable();
        }
    }
}
