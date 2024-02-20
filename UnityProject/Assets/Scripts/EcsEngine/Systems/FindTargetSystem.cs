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
    internal class FindTargetSystem : IEcsRunSystem
    {
        private readonly EcsFilterInject<Inc<Team, Position>> filter;
        private readonly EcsPoolInject<TargetEntity> targetEntityPool;

        void IEcsRunSystem.Run(IEcsSystems systems)
        {
            float deltaTime = Time.deltaTime;

            EcsPool<Team> teamPool = filter.Pools.Inc1;
            EcsPool<Position> positionPool = filter.Pools.Inc2;


            foreach (int entity in filter.Value)
            {
                if (!targetEntityPool.Value.Has(entity))
                {
                    continue;
                }

                ref TargetEntity targetEntity = ref targetEntityPool.Value.Get(entity);
                ref Team team = ref teamPool.Get(entity);
                ref Position position = ref positionPool.Get(entity);

                Vector3 point = Vector3.positiveInfinity;
                targetEntity.value = null;

                foreach (int unit in filter.Value)
                {
                    ref Team targetTeam = ref teamPool.Get(unit);
                    ref Position targetEntityPosition = ref positionPool.Get(unit);


                    if (team.value != targetTeam.value)
                    {
                        var distance = Vector3.Distance(position.value, point);
                        var newDistance = Vector3.Distance(position.value, targetEntityPosition.value);

                        if (newDistance < distance)
                        {
                            targetEntity.value = unit;
                            point = targetEntityPosition.value;
                        }
                    }
                }
            }
        }

    }
}
