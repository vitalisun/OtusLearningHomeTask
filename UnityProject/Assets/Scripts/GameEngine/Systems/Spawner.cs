using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scripts.SaveSystem.Models;
using GameEngine;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.SaveSystem
{
    public class Spawner : MonoBehaviour
    {
        [SerializeField]
        private PrefabCatalog _prefabCatalog;

        public void RespawnUnits(IEnumerable<UnitData> unitEntities, UnitManager service)
        {
            DestroyUnits(service);
            SpawnUnits(unitEntities, service);
        }

        public Unit SpawnUnit(Unit prefab, Vector3 position, Quaternion rotation, Transform parent)
        {
            var unit = Instantiate(prefab, position, rotation, parent);
            return unit;
        }

        private void SpawnUnits(IEnumerable<UnitData> unitEntities, UnitManager service)
        {
            foreach (var unitEntity in unitEntities)
            {
                var unit = _prefabCatalog.prefabs.FirstOrDefault(u => u.Type == unitEntity.Type);
                if (unit != null)
                {
                    var pos = new UnityEngine.Vector3(unitEntity.PositionX, unitEntity.PositionY, unitEntity.PositionZ);
                    var rot = UnityEngine.Quaternion.Euler(0, unitEntity.RotationY, 0);
                    service.SpawnUnit(unit, pos, rot);
                }
            }
        }

        private void DestroyUnits(UnitManager service)
        {
            service.DestroyAll();
        }
    }
}
