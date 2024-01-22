using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Lessons.Architecture.PM
{
    public sealed class CharacterInfoModel
    {
        public event Action<CharacterStatModel> OnStatAdded;
        public event Action<CharacterStatModel> OnStatRemoved;

        private readonly int _maxAmount = 6;
        private readonly HashSet<CharacterStatModel> stats = new();

        public void AddStat(CharacterStatModel stat)
        {
            if (stats.Count >= _maxAmount)
            {
                Debug.Log("Max amount of stats reached");
                return;
            }

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

            return null;
        }

        public CharacterStatModel[] GetStats()
        {
            return stats.ToArray();
        }
    }
}