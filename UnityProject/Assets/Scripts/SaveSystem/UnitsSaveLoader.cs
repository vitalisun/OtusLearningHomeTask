using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.SaveSystem.Models;
using GameEngine;
using Newtonsoft.Json;
using UnityEngine;
using Zenject;

public class UnitsSaveLoader : SaveLoader<UnitsData, UnitManager>
{
    private PrefabCatalog _prefabCatalog;

    [Inject]
    public void Construct(PrefabCatalog prefabCatalog)
    {
        _prefabCatalog = prefabCatalog;
    }

    protected override UnitsData ConvertToData(UnitManager service)
    {
       return new UnitsData()
       {
           Units = service.GetAllUnits().Select(unit => new UnitDto()
           {
               Type = unit.Type,
               PositionX = unit.transform.position.x,
               PositionY = unit.transform.position.y,
               PositionZ = unit.transform.position.z,
               RotationY = unit.transform.rotation.eulerAngles.y
           }).ToList()
       };
    }

    protected override void SetupData(UnitsData data, UnitManager service)
    {
        service.DestroyAll();
        SpawnUnits(data.Units, service);
    }

    protected override void SetupDefaultData(UnitManager service)
    {
        service.DestroyAll();
        SpawnUnits(GetDefaultUnitData(), service);
    }

    private void SpawnUnits(IEnumerable<UnitDto> unitEntities, UnitManager service)
    {

        foreach (var unitEntity in unitEntities)
        {
            var unit = _prefabCatalog.prefabs.FirstOrDefault(u => u.Type == unitEntity.Type);

            if (unit != null)
            {
                var pos = new Vector3(unitEntity.PositionX, unitEntity.PositionY, unitEntity.PositionZ);
                var rot = Quaternion.Euler(0, unitEntity.RotationY, 0);
                service.SpawnUnit(unit, pos, rot);
            }
        }
    }

    private List<UnitDto> GetDefaultUnitData()
    {
        var defaultUnits = new List<UnitDto>
        {
            new()
            {
                Type = _prefabCatalog.prefabs[0].Type,
                PositionX = 0,
                PositionY = 0,
                PositionZ = 0,
                RotationY = 0
            },
            new()
            {
                Type = _prefabCatalog.prefabs[1].Type,
                PositionX = 3,
                PositionY = 0,
                PositionZ = 0,
                RotationY = 0
            },
            new()
            {
                Type = _prefabCatalog.prefabs[2].Type,
                PositionX = 6,
                PositionY = 0,
                PositionZ = 0,
                RotationY = 0
            }
        };
        return defaultUnits;
    }
}