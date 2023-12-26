using Lessons.Architecture.PM;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Homeworks.PresentationModel.Scripts
{
    public class CharacterPopup : MonoBehaviour
    {
        [SerializeField] private UserInfoView _userInfoView;

        [SerializeField] private PlayerLevelView _playerLevelView;

        [SerializeField] private Button _closeButton;

        public void Show(UserInfoPresenter userInfoPresenter, PlayerLevelPresenter playerLevelPresenter)
        {
            gameObject.SetActive(true);
            _closeButton.onClick.AddListener(Hide);

            _userInfoView.Initialized(userInfoPresenter);
            _playerLevelView.Initialized(playerLevelPresenter);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}
