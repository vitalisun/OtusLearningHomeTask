using System.Collections;
using System.Collections.Generic;
using GameEngine;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Unit _unitPrefab;

    private UnitManager _unitManager;
    private ResourceService _resourceService;

    [Inject]
    public void Construct(UnitManager unitManager, ResourceService resourceService)
    {
        _unitManager = unitManager;
        _resourceService = resourceService;

        _unitManager.SetupUnits(FindObjectsOfType<Unit>());
        _resourceService.SetResources(FindObjectsOfType<Resource>());
    }


    private void Update()
    {
        SpawnUnitByClick();
    }

    public void SpawnUnitByClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out var hit, 1000))
            {
                _unitManager.SpawnUnit(_unitPrefab, hit.point, Quaternion.identity);
            }
        }
    }

    [Button]
    public void DestroyUnit(Unit unit)
    {
        _unitManager.DestroyUnit(unit);
    }

    [Button]
    public void ClearAllUnits()
    {
        _unitManager.DestroyAll();
    }

}