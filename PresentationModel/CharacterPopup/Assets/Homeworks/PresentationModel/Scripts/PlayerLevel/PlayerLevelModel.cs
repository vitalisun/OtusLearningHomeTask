using System;
using UnityEngine;

namespace Lessons.Architecture.PM
{
    public sealed class PlayerLevelModel : MonoBehaviour
    {
        public event Action OnLevelUp;
        public event Action<int> OnExperienceChanged;

        public int CurrentLevel { get; private set; } = 1;

        public int CurrentExperience { get; private set; } = 0;

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
            var canLevelUp = CanLevelUp();  

            if (canLevelUp)
            {
                CurrentExperience = 0;
                CurrentLevel++;
                OnLevelUp?.Invoke();
            }
        }

        private bool CanLevelUp()
        {
            return CurrentExperience == RequiredExperience;
        }
    }
}