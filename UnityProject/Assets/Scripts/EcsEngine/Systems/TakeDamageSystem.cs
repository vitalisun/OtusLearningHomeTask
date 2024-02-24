using EcsEngine.Components;
using Leopotam.EcsLite.Di;
using Leopotam.EcsLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Assets.Scripts.EcsEngine.Components;

namespace Assets.Scripts.EcsEngine.Systems
{
    internal class TakeDamageSystem : IEcsRunSystem
    {
        private readonly EcsFilterInject<Inc<AttackRequest>> filter;
        private readonly EcsPoolInject<Damage> damagePool;
        private readonly EcsPoolInject<TargetEntity> targetEntityPool;
        private readonly EcsPoolInject<Health> healthPool;
        private readonly EcsPoolInject<TimeToNextAttack> timeToNextAttackPool;

        void IEcsRunSystem.Run(IEcsSystems systems)
        {
            EcsPool<AttackRequest> attackRequestPool = filter.Pools.Inc1;

            foreach (int entity in filter.Value)
            {
                ref TargetEntity targetEntity = ref targetEntityPool.Value.Get(entity);
                if (targetEntity.value == null)
                {
                    continue;
                }

                ref Damage damage = ref damagePool.Value.Get(entity);
                ref Health health = ref healthPool.Value.Get(targetEntity.value.Value);
                ref TimeToNextAttack timeToNextAttack = ref timeToNextAttackPool.Value.Get(entity);

                health.value = Mathf.Max(0, health.value - damage.value);

                attackRequestPool.Del(entity);
                timeToNextAttack.Reset();

                Debug.Log($"Entity id {entity} time to next attack reloaded");
            }
        }
    }
}
