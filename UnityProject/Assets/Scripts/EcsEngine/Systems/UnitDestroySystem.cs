using EcsEngine.Components;
using Leopotam.EcsLite.Di;
using Leopotam.EcsLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sirenix.OdinInspector.Editor;
using UnityEngine;

namespace Assets.Scripts.EcsEngine.Systems
{
    internal class UnitDestroySystem : IEcsRunSystem
    {
        private readonly EcsFilterInject<Inc<Health>> filter;

        private readonly EcsCustomInject<UnitManager> _unitManager = default;
        void IEcsRunSystem.Run(IEcsSystems systems)
        {
            float deltaTime = Time.deltaTime;

            EcsPool<Health> healthPool = filter.Pools.Inc1;


            foreach (int entity in filter.Value)
            {
                ref Health health = ref healthPool.Get(entity);

              

                if (health.value <=0)
                {
                   _unitManager.Value.Destroy(entity);
                }
            }
        }
    }
}
