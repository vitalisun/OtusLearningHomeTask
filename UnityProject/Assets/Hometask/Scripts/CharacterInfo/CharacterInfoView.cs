using System;
using System.Collections.Generic;
using Assets.Homeworks.PresentationModel.Scripts.CharacterStat;
using UnityEngine;

namespace Lessons.Architecture.PM
{
    public sealed class CharacterInfoView : MonoBehaviour
    {
        [SerializeField]
        private Transform _statsContainer;

        [SerializeField]
        private Transform[] _statSlots = new Transform[6];

        [SerializeField]
        private GameObject _statPrefab;

        private CharacterInfoPresenter _presenter;
        private Dictionary<CharacterStatModel, GameObject> _statViews = new();

        public void Initialize(CharacterInfoPresenter presenter)
        {
            _presenter = presenter;
            _presenter.OnStatAdded += AddStatUi;
            _presenter.OnStatRemoved += RemoveStatUi;

            foreach (var stat in _presenter.GetStats())
            {
                AddStatUi(stat);
            }
        }

        private void AddStatUi(CharacterStatModel stat)
        {
            if(_statViews.ContainsKey(stat))
                return;

            int emptySlotIndex = Array.FindIndex(_statSlots, slot => slot.childCount == 0);

            if (emptySlotIndex != -1)
            {
                var statViewObject = Instantiate(_statPrefab, _statSlots[emptySlotIndex]);
                var statView = statViewObject.GetComponent<CharacterStatView>();
                var statPresenter = new CharacterStatPresenter(stat);
                statView.Initialize(statPresenter);
                _statViews.Add(stat, statViewObject);
            }
            else
            {
                Debug.Log("Maximum amount of stats reached");
            }
        }

        private void RemoveStatUi(CharacterStatModel stat)
        {
            if (_statViews.TryGetValue(stat, out var statViewObject))
            {
                Destroy(statViewObject);
                _statViews.Remove(stat);
            }
        }

        private void OnDestroy()
        {
            _presenter.OnStatAdded -= AddStatUi;
            _presenter.OnStatRemoved -= RemoveStatUi;
        }
    }
}