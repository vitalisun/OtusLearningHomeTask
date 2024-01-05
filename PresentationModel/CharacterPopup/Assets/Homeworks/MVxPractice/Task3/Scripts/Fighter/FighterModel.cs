using UnityEngine;

namespace Assets.Homeworks.MVxPractice.Task3.Scripts.Fighter
{
    public class FighterModel
    {
        public string Name { get; }
        public Sprite Icon { get; }

        public FighterModel(string name, Sprite icon)
        {
            Name = name;
            Icon = icon;
        }
    }
}
