using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Lessons.Architecture.PM
{
    public sealed class UserInfoView : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI _nameText;

        [SerializeField]
        private TextMeshProUGUI _descriptionText;

        [SerializeField]
        private Image _iconImage;

        private UserInfoPresenter _presenter;

        public void Initialize(UserInfoPresenter presenter)
        {
            _presenter = presenter;
            SetName(_presenter.Name);
            SetDescription(_presenter.Description);
            SetIcon(_presenter.Icon);

            _presenter.OnNameChanged += SetName;
            _presenter.OnDescriptionChanged += SetDescription;
            _presenter.OnIconChanged += SetIcon;
        }

        public void SetName(string name)
        {
            _nameText.text = name;
        }

        public void SetDescription(string description)
        {
            _descriptionText.text = description;
        }

        public void SetIcon(Sprite icon)
        {
            _iconImage.sprite = icon;
        }

        private void OnDestroy()
        {
            _presenter.OnNameChanged -= SetName;
            _presenter.OnDescriptionChanged -= SetDescription;
            _presenter.OnIconChanged -= SetIcon;
        }
    }
}