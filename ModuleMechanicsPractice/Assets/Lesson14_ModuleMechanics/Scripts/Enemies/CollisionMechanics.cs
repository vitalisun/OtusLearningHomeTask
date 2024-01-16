using Assets.Lesson14_ModuleMechanics.Scripts;
using Lessons.Lesson14_ModuleMechanics;
using UnityEngine;

public class CollisionMechanics
{
    private AtomicVariable<int> _damage;

    public CollisionMechanics(AtomicVariable<bool> canMove, AtomicVariable<int> damage)
    {
        _damage = damage;
    }

    public void OnTriggerEnter(Collider other)
    {

        if (other.TryGetComponent(out Character character))
        {
            character.TakeDamage.Invoke(_damage.Value);
        }
    }
}