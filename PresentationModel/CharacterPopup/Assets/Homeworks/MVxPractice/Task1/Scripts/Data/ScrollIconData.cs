using UnityEngine;

namespace Assets.Homeworks.MVxPractice.Task1.Scripts.Data
{
    [CreateAssetMenu(fileName = "ScrollIconData", menuName = "Data/ScrollIconData")]
    public class ScrollIconData : ScriptableObject
    {
        [SerializeField] private Sprite _icon;
        [SerializeField] private string _text;
        public Sprite Icon => _icon;
        public string Text => _text;
    }
}
