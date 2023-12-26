using System;
using UnityEngine;

namespace Lessons.Architecture.PM
{
    public sealed class CharacterStatModel : MonoBehaviour
    {
        public event Action<int> OnValueChanged; 

        public string Name { get; private set; }

        public int Value { get; private set; }

        public CharacterStatModel(string name, int value)
        {
            Name = name;
            Value = value;
        }

        public void ChangeValue(int value)
        {
            Value = value;
            OnValueChanged?.Invoke(value);
        }
    }
}