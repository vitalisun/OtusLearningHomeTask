using UnityEngine;
using Zenject;

namespace Assets.Homeworks.MVxPractice.Task2.Scripts
{
    public class ClickerManager : MonoBehaviour
    {
        private ClickerView _clickerPrefab;
        private ClickerCharacterData[] _clickerCharacters;
        private ClickerView _clickerView;
        private ClickerPresenter _clickerPresenter;

        [Inject]
        public void Construct(ClickerView clickerPrefab, ClickerCharacterData[] clickerCharacters)
        {
            _clickerPrefab = clickerPrefab;
            _clickerCharacters = clickerCharacters;
        }

        public void Create()
        {
            var clickerModel = new ClickerModel(_clickerCharacters);
            _clickerPresenter = new ClickerPresenter(clickerModel);
            _clickerView = Instantiate(_clickerPrefab);
            _clickerView.Init(_clickerPresenter);
        }

        public void Destroy()
        {
            _clickerPresenter.Dispose();
            Destroy(_clickerView.gameObject);
        }
    }
}
