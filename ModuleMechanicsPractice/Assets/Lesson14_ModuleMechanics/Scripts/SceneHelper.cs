using Lessons.Lesson14_ModuleMechanics;
using UnityEngine;

namespace Assets.Lesson14_ModuleMechanics.Scripts
{
    public class SceneHelper : MonoBehaviour
    {
        [SerializeField] private Character _character;
        [SerializeField] private int _hitPoints;
        [SerializeField] private int _damage;

        private void Awake()
        {
            _character.HitPoints.Value = 10;
            _hitPoints = _character.HitPoints.Value;
            Debug.Log($"Character {_character.name} has {_character.HitPoints.Value} hit points.");
        }

        private void TakeDamage()
        {
            _character.TakeDamage.Invoke(_damage);
            _hitPoints = _character.HitPoints.Value;
        }
    }
}
