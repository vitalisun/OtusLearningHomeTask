using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.SaveSystem;
using Assets.Scripts.SaveSystem.Models;
using GameEngine;
using Newtonsoft.Json;
using UnityEngine;
using Zenject;

public class UnitsSaveLoader : SaveLoader<UnitsData, UnitManager>
{
    private Spawner _spawner;

    [Inject]
    public void Construct(Spawner spawner)
    {
        _spawner = spawner;
    }

    protected override UnitsData ConvertToData(UnitManager service)
    {
       return new UnitsData()
       {
           Units = service.GetAllUnits().Select(unit => new UnitData()
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
       _spawner.RespawnUnits(data.Units, service);
    }


}