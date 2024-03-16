using Assets.Scripts.EcsEngine.Components;
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
        private readonly EcsPoolInject<TimeToNextAttack> timeToNextAttackPool;
        private readonly EcsPoolInject<EntityRadius> entityRadiusPool;
        private readonly EcsPoolInject<AnimatorView> animatorPool;

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
                ref TimeToNextAttack timeToNextAttack = ref timeToNextAttackPool.Value.Get(entity);
                ref EntityRadius entityRadius = ref entityRadiusPool.Value.Get(targetEntity.value.Value);
                ref AnimatorView animatorView = ref animatorPool.Value.Get(entity);

                var attackDistance = entityRadius.value + attackRange.value;

                if (Vector3.Distance(position.value, targetPosition.value) > attackDistance)
                {
                    position.value = Vector3.MoveTowards(position.value, targetPosition.value, moveSpeed.value * deltaTime);
                    animatorView.value.SetInteger("AnimState", 1);
                }
                else
                {
                    if (timeToNextAttack.value <= 0)
                    {
                        attackRequestPool.Value.Add(entity);
                        animatorView.value.SetInteger("AnimState", 2);
                    }
                    else
                    {
                        animatorView.value.SetInteger("AnimState", 0);
                    }

                }

                timeToNextAttack.value -= deltaTime;

                if (rotationPool.Value.Has(entity))
                {
                    ref Rotation rotation = ref rotationPool.Value.Get(entity);
                    rotation.value = Quaternion.LookRotation(targetPosition.value - position.value);
                }
            }
        }
    }
}
