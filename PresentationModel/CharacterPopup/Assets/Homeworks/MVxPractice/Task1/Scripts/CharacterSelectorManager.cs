using Assets.Homeworks.MVxPractice.Task1.Scripts.Data;
using UnityEngine;

namespace Assets.Homeworks.MVxPractice.Task1.Scripts
{
    public class CharacterSelectorManager : MonoBehaviour
    {
        [SerializeField] private CharacterSelector _characterSelectorPrefab;
        [SerializeField] private ScrollIconData[] _scrollIconDataList;
        private ScrollerPresenter _scrollerPresenter;
        private CharacterSelector _characterSelector;

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
