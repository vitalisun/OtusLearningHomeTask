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

        public void ShowPopup()
        {
            if (_characterPopup.gameObject.activeSelf)
            {
                return;
            }

            _characterPopup.Show(CreateUserInfoPresenter());
        }

        private UserInfoPresenter CreateUserInfoPresenter()
        {
            var userInfoModel = _userInfoModelFactory.CreateUserInfoModel();

            return new UserInfoPresenter(userInfoModel);
        }
    }
}
