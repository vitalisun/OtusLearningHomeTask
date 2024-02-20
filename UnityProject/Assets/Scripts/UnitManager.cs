using Leopotam.EcsLite.Entities;
using Leopotam.EcsLite;
using System.Collections.Generic;
using Assets.Scripts.Content;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

namespace Assets.Scripts
{
    public sealed class UnitManager
    {
        private const int InitialCount = 10;
        private EcsWorld world;

        private readonly Dictionary<int, Entity> entities = new();
        private List<UnitPool> _pools;

        public void Initialize(EcsWorld world, Dictionary<TeamEnum, Entity[]> prefabs, Transform poolContainer)
        {
            this.world = world;

            _pools = new List<UnitPool>();

            foreach (var entities in prefabs)
            {
                var unitPool = new UnitPool(InitialCount);

                for (int i = 0; i < InitialCount; i++)
                {
                    var randomNum = Random.Range(0, entities.Value.Length);
                    var entity = entities.Value[randomNum];

                    unitPool.InitPool(entity.gameObject, poolContainer);
                }
                _pools.Add(unitPool);

            }
        }

        //public Entity Create(Vector3 position, TeamEnum team, Transform parent = null)
        //{
        //    Entity entity = _pools[(int)team].GetFromPool();
        //    entity.Initialize(this.world);
        //    this.entities.Add(entity.Id, entity);
        //    return entity;
        //}

        public void Destroy(int id)
        {
            if (this.entities.Remove(id, out Entity entity))
            {
                entity.Dispose();
                entity.gameObject.SetActive(false); //todo: return to pool
            }
        }


        public Entity Get(int id)
        {
            return this.entities[id];
        }
    }
}
