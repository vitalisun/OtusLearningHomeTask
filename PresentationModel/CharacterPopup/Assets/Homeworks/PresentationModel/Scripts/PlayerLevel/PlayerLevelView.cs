using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Lessons.Architecture.PM
{
    public sealed class PlayerLevelView : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI _levelText;

        [SerializeField]
        private TextMeshProUGUI _XPText;

        [SerializeField]
        private Slider _slider;

        [SerializeField]
        private Button _levelUpButton;

        private PlayerLevelPresenter _presenter;

        public void Initialize(PlayerLevelPresenter presenter)
        {
            _presenter = presenter;

            _levelText.text = _presenter.LevelText;
            _XPText.text = _presenter.XPText;
            _slider.value = _presenter.SliderValue;
           
            _levelUpButton.onClick.AddListener(LevelUp);
            _presenter.OnLevelUp += SetLevel;
            _presenter.OnExperienceChanged += SetExperience;
        }

        private void LevelUp()
        {
            _presenter.LevelUp();
        }

        private void SetExperience()
        {
            _XPText.text = _presenter.XPText;
            _slider.value = _presenter.SliderValue;
        }

        private void SetLevel()
        {
            _levelText.text = _presenter.LevelText;
            _XPText.text = _presenter.XPText;
            _slider.value = _presenter.SliderValue;
        }

        private void OnDestroy()
        {
            _levelUpButton.onClick.RemoveListener(_presenter.LevelUp);
            _presenter.OnLevelUp -= SetLevel;
            _presenter.OnExperienceChanged -= SetExperience;
        }
    }
}