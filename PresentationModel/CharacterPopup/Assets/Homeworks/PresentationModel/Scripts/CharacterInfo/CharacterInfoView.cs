using System;
using System.Collections.Generic;
using Assets.Homeworks.PresentationModel.Scripts.CharacterStat;
using UnityEngine;

namespace Lessons.Architecture.PM
{
    public sealed class CharacterInfoView : MonoBehaviour
    {
        [SerializeField]
        private Transform statsContainer; // Parent object for stat UI elements

        [SerializeField]
        private Transform[] _statSlots = new Transform[6];

        // Reference to a prefab representing a single stat in the UI
        [SerializeField]
        private GameObject statPrefab;

        private CharacterInfoPresenter _presenter;
        private Dictionary<CharacterStatModel, GameObject> statViews = new();

        public void Initialize(CharacterInfoPresenter presenter)
        {
            _presenter = presenter;
            _presenter.OnStatAdded += AddStatUI;
            _presenter.OnStatRemoved += RemoveStatUI;

            foreach (var stat in _presenter.GetStats())
            {
                AddStatUI(stat);
            }
        }

        private void AddStatUI(CharacterStatModel stat)
        {
            if(statViews.ContainsKey(stat))
                return;

            // Find the first empty slot
            int emptySlotIndex = Array.FindIndex(_statSlots, slot => slot.childCount == 0);

            // Check if an empty slot is found
            if (emptySlotIndex != -1)
            {
                // Instantiate the stat view in the empty slot
                var statViewObject = Instantiate(statPrefab, _statSlots[emptySlotIndex]);
                var statView = statViewObject.GetComponent<CharacterStatView>();
                var statPresenter = new CharacterStatPresenter(stat);
                statView.Initialize(statPresenter);
                statViews.Add(stat, statViewObject);
            }
            else
            {
                // All slots are filled, display a warning
                Debug.Log("Maximum amount of stats reached");
            }
        }

        private void RemoveStatUI(CharacterStatModel stat)
        {
            if (statViews.TryGetValue(stat, out var statViewObject))
            {
                Destroy(statViewObject);
                statViews.Remove(stat);
            }
        }

        private void OnDestroy()
        {
            _presenter.OnStatAdded -= AddStatUI;
            _presenter.OnStatRemoved -= RemoveStatUI;
        }

        // Additional methods for UI interaction can be added here
    }
}