using System;
using UnityEngine;

namespace Lessons.Architecture.PM
{
    public sealed class PlayerLevel : MonoBehaviour
    {
        public event Action OnLevelUp;
        public event Action<int> OnExperienceChanged;

        public int CurrentLevel { get; private set; } = 1;

        public int CurrentExperience { get; private set; }

        public int RequiredExperience
        {
            get { return 100 * (CurrentLevel + 1); }
        }

        public void AddExperience(int range)
        {
            var xp = Math.Min(CurrentExperience + range, RequiredExperience);
            CurrentExperience = xp;
            OnExperienceChanged?.Invoke(xp);
        }

        public void LevelUp()
        {
            if (CanLevelUp())
            {
                CurrentExperience = 0;
                CurrentLevel++;
                OnLevelUp?.Invoke();
            }
        }

        public bool CanLevelUp()
        {
            return CurrentExperience == RequiredExperience;
        }
    }
}