using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Lessons.Architecture.PM
{
    public sealed class CharacterInfoModel : MonoBehaviour
    {
        public event Action<CharacterStatModel> OnStatAdded;
        public event Action<CharacterStatModel> OnStatRemoved;
    
        private readonly HashSet<CharacterStatModel> stats = new();

        public void AddStat(CharacterStatModel stat)
        {
            if (stats.Add(stat))
            {
                OnStatAdded?.Invoke(stat);
            }
        }

        public void RemoveStat(CharacterStatModel stat)
        {
            if (stats.Remove(stat))
            {
                OnStatRemoved?.Invoke(stat);
            }
        }

        public CharacterStatModel GetStat(string name)
        {
            foreach (var stat in stats)
            {
                if (stat.Name == name)
                {
                    return stat;
                }
            }

            throw new Exception($"Stat {name} is not found!");
        }

        public CharacterStatModel[] GetStats()
        {
            return stats.ToArray();
        }
    }
}