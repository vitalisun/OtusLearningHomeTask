using System.Collections.Generic;
using System.Linq;
using Assets.Homeworks.MVxPractice.Task3.Scripts.Fighter;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FightingSelectorView : MonoBehaviour
{
    [SerializeField] private Transform _slotsParent;
    [SerializeField] private FighterView _fighterViewPrefab;
    [SerializeField] Image _selectedFighterImage;
    [SerializeField] TextMeshProUGUI _selectedFighterName;

    private Transform[] _slots;
    private List<FighterView> _fighterViews = new();


    public void Init(FighterData[] fighterDatas)
    {
        _slots = _slotsParent
            .GetComponentsInChildren<Transform>()
            .Where(t => t != _slotsParent)
            .ToArray();

        foreach (var fighterData in fighterDatas)
        {
            var availableSlot = GetFirstEmptySlot();

            if (availableSlot == null)
            {
                break;
            }

            var fighterModel = new FighterModel(fighterData.Name, fighterData.Icon);
            var fighterPresenter = new FighterPresenter(fighterModel);
            var fighterView = Instantiate(_fighterViewPrefab, availableSlot);
            fighterView.Initialize(fighterPresenter);

            fighterView.OnFighterSelect += OnFighterSelectHandler;

            _fighterViews.Add(fighterView);
        }
    }

    private void OnFighterSelectHandler(string name)
    {
        var fighterView = _fighterViews.FirstOrDefault(f => f.Name.text == name);

        _selectedFighterImage.sprite = fighterView.Icon.sprite;
        _selectedFighterName.text = fighterView.Name.text;
    }

    private Transform GetFirstEmptySlot()
    {
        foreach (var slot in _slots)
        {
            if (slot.childCount == 0)
            {
                return slot;
            }
        }

        return null;
    }

    private void OnDestroy()
    {
        foreach (var fighterView in _fighterViews)
        {
            fighterView.OnFighterSelect -= OnFighterSelectHandler;
        }
    }

}