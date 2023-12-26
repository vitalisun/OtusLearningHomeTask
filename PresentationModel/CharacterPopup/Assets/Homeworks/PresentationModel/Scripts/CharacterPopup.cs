using Lessons.Architecture.PM;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Homeworks.PresentationModel.Scripts
{
    public class CharacterPopup : MonoBehaviour
    {
        [SerializeField] private UserInfoView _userInfoView;

        [SerializeField] private Button _closeButton;

        public void Show(UserInfoPresenter presenter)
        {
            gameObject.SetActive(true);
            _closeButton.onClick.AddListener(Hide);

            _userInfoView.Initialized(presenter);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}
