using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using Assets.Scripts.Content;
using EcsEngine;
using Sirenix.OdinInspector;
using UnityEngine;

public class Helper : MonoBehaviour
{
    private EcsAdmin _ecsAdmin;

    void Awake()
    {
        _ecsAdmin = GetComponent<EcsAdmin>();

    }

    [Button]
    public void CreateRedUnit()
    {
        var position = _ecsAdmin._redSpawnPoints[Random.Range(0, _ecsAdmin._redSpawnPoints.Count)].position;

        _ecsAdmin.UnitManager.Create(position, TeamEnum.Red, _ecsAdmin.UnitsContainer.transform);
    }

    [Button]
    public void CreateBlueUnit()
    {
        var position = _ecsAdmin._blueSpawnPoints[Random.Range(0, _ecsAdmin._blueSpawnPoints.Count)].position;
        _ecsAdmin.UnitManager.Create(position, TeamEnum.Blue, _ecsAdmin.UnitsContainer.transform);
    }
}
