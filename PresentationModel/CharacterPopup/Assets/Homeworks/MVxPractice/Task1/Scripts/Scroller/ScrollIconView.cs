using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Homeworks.MVxPractice.Task1.Scripts.Scroller
{
    public class ScrollIconView: MonoBehaviour
    {
        [SerializeField] private Canvas _canvas;
        [SerializeField] private Image _image;
        [SerializeField] private TextMeshProUGUI _text;

        public Canvas Canvas => _canvas;
        public Image Image => _image;
        public TextMeshProUGUI Text => _text;
    }
}
