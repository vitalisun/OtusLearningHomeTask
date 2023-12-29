using System;

namespace Lessons.Architecture.PM
{
    public sealed class CharacterStatModel
    {
        public event Action<int> OnValueChanged; 

        public string Name { get; private set; }

        public int Value { get; private set; }

        public CharacterStatModel(string name)
        {
            Name = name;
        }

        public void ChangeValue(int value)
        {
            Value = value;
            OnValueChanged?.Invoke(value);
        }
    }
}