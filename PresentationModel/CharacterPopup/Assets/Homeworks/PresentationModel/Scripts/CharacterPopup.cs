using Lessons.Architecture.PM;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Homeworks.PresentationModel.Scripts
{
    public class CharacterPopup : MonoBehaviour
    {
        [SerializeField] private UserInfoView _userInfoView;

        [SerializeField] private PlayerLevelView _playerLevelView;

        [SerializeField] private CharacterInfoView _characterInfoView;

        [SerializeField] private Button _closeButton;

        public void Show(
            UserInfoPresenter userInfoPresenter, 
            PlayerLevelPresenter playerLevelPresenter, 
            CharacterInfoPresenter characterInfoPresenter)
        {
            gameObject.SetActive(true);
            _closeButton.onClick.AddListener(Hide);

            _userInfoView.Initialize(userInfoPresenter);
            _playerLevelView.Initialize(playerLevelPresenter);
            _characterInfoView.Initialize(characterInfoPresenter);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}
