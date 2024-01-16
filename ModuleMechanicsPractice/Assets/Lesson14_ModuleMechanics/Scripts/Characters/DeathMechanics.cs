using Lessons.Lesson14_ModuleMechanics;
using UnityEngine;

namespace Assets.Lesson14_ModuleMechanics.Scripts
{
    public class DeathMechanics
    {
        private AtomicVariable<int> _hitPoints;
        private AtomicVariable<bool> _isDead;
        private AtomicEvent _death;

        public DeathMechanics(AtomicVariable<int> hitPoints, AtomicVariable<bool> isDead, AtomicEvent death)
        {
            _hitPoints = hitPoints;
            _isDead = isDead;
            _death = death;
        }

        public void OnEnable()
        {
            _hitPoints.Subscribe(OnHitPointsChanged);
        }

        public void OnDisable()
        {
            _hitPoints.Unsubscribe(OnHitPointsChanged);
        }

        private void OnHitPointsChanged(int hitPoints)
        {
            if (_isDead.Value)
            {
                return;
            }

            if (hitPoints <= 0)
            {
                _isDead.Value = true;
                _death.Invoke();

            }

            Debug.Log($"hitPoints: {_hitPoints.Value}, isDead: {_isDead.Value}");
        }
    }
}