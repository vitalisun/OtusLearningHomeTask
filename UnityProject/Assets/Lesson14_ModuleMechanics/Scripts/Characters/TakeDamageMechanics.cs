using System;
using Lessons.Lesson14_ModuleMechanics;
using UnityEngine;

namespace Assets.Lesson14_ModuleMechanics.Scripts
{
    public class TakeDamageMechanics
    {
        private AtomicVariable<int> _hitPoints;
        private AtomicEvent<int> _takeDamage;

        public TakeDamageMechanics(AtomicVariable<int> hitPoints, AtomicEvent<int> takeDamage)
        {
            _hitPoints = hitPoints;
            _takeDamage = takeDamage;
        }

        public void OnEnable()
        {
            _takeDamage.Subscribe(OnTakeDamage);
        }

        public void OnDisable()
        {
            _takeDamage.Unsubscribe(OnTakeDamage);
        }

        private void OnTakeDamage(int damage)
        {
            var hitPoints = _hitPoints.Value - damage;

            _hitPoints.Value = (int)MathF.Max(0, hitPoints);
        }
    }
}