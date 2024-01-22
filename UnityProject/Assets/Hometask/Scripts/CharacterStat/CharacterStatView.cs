using TMPro;
using UnityEngine;

namespace Assets.Homeworks.PresentationModel.Scripts.CharacterStat
{
    public sealed class CharacterStatView : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI _statText;

        private CharacterStatPresenter _presenter;

        public void Initialize(CharacterStatPresenter presenter)
        {
            _presenter = presenter;
            _presenter.OnValueChanged += UpdateUI;

            UpdateUI(); // Initial UI update
        }

        private void UpdateUI()
        {
            _statText.text = _presenter.StatText;
        }

        private void OnDestroy()
        {
            _presenter.OnValueChanged -= UpdateUI;
        }
    }
}