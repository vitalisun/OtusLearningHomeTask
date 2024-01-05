using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Homeworks.MVxPractice.Task3.Scripts.Fighter
{
    public class FighterView : MonoBehaviour
    {
        public Image Icon => _icon;
        public TextMeshProUGUI Name => _name;

        public event Action<string> OnFighterSelect;

        private FighterPresenter _presenter;
        private Image _icon;
        private TextMeshProUGUI _name;
        private Button _selectButton;


        public void Initialize(FighterPresenter presenter)
        {
            _icon = GetComponentInChildren<Image>();
            _name = GetComponentInChildren<TextMeshProUGUI>();
            _selectButton = GetComponentInChildren<Button>();

            _selectButton.onClick.AddListener(OnSelectButtonClick);

            _presenter = presenter;
            _icon.sprite = _presenter.Icon;
            _name.text = _presenter.Name;
        }

        private void OnSelectButtonClick()
        {
            OnFighterSelect?.Invoke(_presenter.Name);
        }

        private void OnDestroy()
        {
            _selectButton.onClick.RemoveListener(OnSelectButtonClick);
        }
    }
}