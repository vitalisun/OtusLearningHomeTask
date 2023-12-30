using Assets.Homeworks.MVxPractice.Task1.Scripts.Data;
using UnityEngine;
using Zenject;

namespace Assets.Homeworks.MVxPractice.Task1.Scripts
{
    public class CharacterSelectorManager : MonoBehaviour
    {
        private CharacterSelector _characterSelectorPrefab;
        private ScrollIconData[] _scrollIconDataList;
        private ScrollerPresenter _scrollerPresenter;
        private CharacterSelector _characterSelector;

        [Inject]
        public void Construct(CharacterSelector characterSelectorPrefab, ScrollIconData[] scrollIconDataList)
        {
            _characterSelectorPrefab = characterSelectorPrefab;
            _scrollIconDataList = scrollIconDataList;
        }

        public void Create()
        {
            var scrollerModel = new ScrollerModel(_scrollIconDataList);
            _scrollerPresenter = new ScrollerPresenter(scrollerModel);

            _characterSelector = Instantiate(_characterSelectorPrefab);
            _characterSelector.Show(_scrollerPresenter);
        }

        public void Destroy()
        {
            _scrollerPresenter.Dispose();
            Destroy(_characterSelector.gameObject);
        }
    }
}
