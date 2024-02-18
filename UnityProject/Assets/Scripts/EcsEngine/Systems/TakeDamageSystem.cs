using EcsEngine.Components;
using Leopotam.EcsLite.Di;
using Leopotam.EcsLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.EcsEngine.Systems
{
    internal class TakeDamageSystem : IEcsRunSystem
    {
        private readonly EcsFilterInject<Inc<AttackRequest>> filter;
        private readonly EcsPoolInject<Damage> damagePool;
        private readonly EcsPoolInject<TargetEntity> targetEntityPool;
        private readonly EcsPoolInject<Health> healthPool;
        void IEcsRunSystem.Run(IEcsSystems systems)
        {
            EcsPool<AttackRequest> attackRequestPool = filter.Pools.Inc1;

            foreach (int entity in filter.Value)
            {
                ref Damage damage = ref damagePool.Value.Get(entity);
                ref TargetEntity targetEntity = ref targetEntityPool.Value.Get(entity);
                ref Health health = ref healthPool.Value.Get(targetEntity.value);

                health.value = Mathf.Max(0, health.value - damage.value);

                attackRequestPool.Del(entity);
            }
        }
    }
}
