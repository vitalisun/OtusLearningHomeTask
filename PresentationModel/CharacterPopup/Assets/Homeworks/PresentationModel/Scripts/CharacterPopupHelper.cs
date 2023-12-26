using Lessons.Architecture.PM;
using UnityEngine;

namespace Assets.Homeworks.PresentationModel.Scripts
{
    public class CharacterPopupHelper : MonoBehaviour
    {
        [SerializeField]
        private CharacterPopup _characterPopup;

        [SerializeField]
        private UserInfoModelFactory _userInfoModelFactory;

        private PlayerLevelPresenter _playerLevelPresenter;
        private UserInfoPresenter _userInfoPresenter;

        public void ShowPopup()
        {
            if (_characterPopup.gameObject.activeSelf)
            {
                return;
            }

            if (_userInfoPresenter == null)
            {
                _userInfoPresenter = CreateUserInfoPresenter();
            }

            if (_playerLevelPresenter == null)
            {
                _playerLevelPresenter = CreatePlayerLevelPresenter();
            }

            _characterPopup.Show(_userInfoPresenter, _playerLevelPresenter);
        }

        public void AddExperience(int range)
        {
            _playerLevelPresenter.AddExperience(range);
        }

        private PlayerLevelPresenter CreatePlayerLevelPresenter()
        {
            var playerLevelModel = new PlayerLevelModel();

            return new PlayerLevelPresenter(playerLevelModel);
        }

        private UserInfoPresenter CreateUserInfoPresenter()
        {
            var userInfoModel = _userInfoModelFactory.CreateUserInfoModel();

            return new UserInfoPresenter(userInfoModel);
        }
    }
}
