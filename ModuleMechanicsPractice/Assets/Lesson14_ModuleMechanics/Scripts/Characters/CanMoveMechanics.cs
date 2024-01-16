using Lessons.Lesson14_ModuleMechanics;

namespace Assets.Lesson14_ModuleMechanics.Scripts
{
    public class CanMoveMechanics
    {
        private AtomicVariable<bool> _canMove;
        private AtomicVariable<bool> _isDead;

        public CanMoveMechanics(AtomicVariable<bool> canMove, AtomicVariable<bool> isDead)
        {
            _canMove = canMove;
            _isDead = isDead;
        }

        public void Update()
        {
            _canMove.Value = CanMove();
        }

        private bool CanMove()
        {
            return !_isDead.Value;
        }

    }
}