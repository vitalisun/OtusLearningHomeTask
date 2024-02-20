using EcsEngine.Components;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;

namespace EcsEngine.Systems
{
    internal sealed class AttackSystem : IEcsRunSystem
    {
        private readonly EcsFilterInject<Inc<TargetEntity, MoveSpeed, Position, AttackRange>> filter;
        private readonly EcsPoolInject<Rotation> rotationPool;
        private readonly EcsPoolInject<AttackRequest> attackRequestPool;
        private readonly EcsPoolInject<Position> targetPositionPool;
        void IEcsRunSystem.Run(IEcsSystems systems)
        {
            float deltaTime = Time.deltaTime;

            EcsPool<TargetEntity> targetEntityPool = filter.Pools.Inc1;
            EcsPool<MoveSpeed> speedPool = filter.Pools.Inc2;
            EcsPool<Position> positionPool = filter.Pools.Inc3;
            EcsPool<AttackRange> attackRangePool = filter.Pools.Inc4;

            foreach (int entity in filter.Value)
            {
                ref TargetEntity targetEntity = ref targetEntityPool.Get(entity);
                if (!targetEntity.value.HasValue)
                    continue;

                Position targetPosition = targetPositionPool.Value.Get(targetEntity.value.Value);
                MoveSpeed moveSpeed = speedPool.Get(entity);
                ref Position position = ref positionPool.Get(entity);
                ref AttackRange attackRange = ref attackRangePool.Get(entity);

                if (Vector3.Distance(position.value, targetPosition.value) > attackRange.value)
                {
                    position.value = Vector3.MoveTowards(position.value, targetPosition.value, moveSpeed.value * deltaTime);
                }
                else
                {
                    attackRequestPool.Value.Add(entity);
                }

                if (rotationPool.Value.Has(entity))
                {
                    ref Rotation rotation = ref rotationPool.Value.Get(entity);
                    rotation.value = Quaternion.LookRotation(targetPosition.value - position.value);
                }
            }
        }
    }
}
