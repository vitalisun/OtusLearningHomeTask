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
        private readonly HashSet<CharacterStatModel> _stats = new();

        public void AddStat(CharacterStatModel stat)
        {
            if (_stats.Count >= _maxAmount)
            {
                Debug.Log("Max amount of stats reached");
                return;
            }

            if (_stats.Add(stat))
            {
                OnStatAdded?.Invoke(stat);
            }
        }

        public void RemoveStat(CharacterStatModel stat)
        {
            if (_stats.Remove(stat))
            {
                OnStatRemoved?.Invoke(stat);
            }
        }

        public CharacterStatModel GetStat(string name)
        {
            foreach (var stat in _stats)
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
            return _stats.ToArray();
        }
    }
}