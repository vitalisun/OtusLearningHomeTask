using Lessons.Architecture.PM;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Homeworks.PresentationModel.Scripts
{
    public class CharacterPopup : MonoBehaviour
    {
        [SerializeField] private GameObject _root;
        [SerializeField] private UserInfoView _userInfoView;
        [SerializeField] private PlayerLevelView _playerLevelView;
        [SerializeField] private CharacterInfoView _characterInfoView;
        [SerializeField] private Button _closeButton;

        public GameObject Root => _root;

        public void Show(
            UserInfoPresenter userInfoPresenter, 
            PlayerLevelPresenter playerLevelPresenter, 
            CharacterInfoPresenter characterInfoPresenter)
        {
            if (_root == null)
            {
                Debug.Log("Root not found");
                return;
            }

            if (_root.activeSelf)
            {
                return;
            }

            _root.SetActive(true);
            _closeButton.onClick.AddListener(Hide);

            _userInfoView.Initialize(userInfoPresenter);
            _playerLevelView.Initialize(playerLevelPresenter);
            _characterInfoView.Initialize(characterInfoPresenter);
        }

        public void Hide()
        {
            if (_root == null)
            {
                Debug.Log("Root not found");
                return;
            }

            if (!_root.activeSelf)
            {
                return;
            }

            _root.SetActive(false);
        }
    }
}
