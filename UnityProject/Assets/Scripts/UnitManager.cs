using Leopotam.EcsLite.Entities;
using Leopotam.EcsLite;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Content;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

namespace Assets.Scripts
{
    public sealed class UnitManager
    {
        private const int InitialCount = 10;
        private EcsWorld _world;

        private readonly Dictionary<int, Entity> entities = new();
        private Dictionary<TeamEnum, UnitPool> _pools;

        public void Initialize(EcsWorld world, Dictionary<TeamEnum, TeamDescription> teams, Transform poolContainer)
        {
            _world = world;
            InitializeOnScene();

            _pools = new Dictionary<TeamEnum, UnitPool>();

            foreach (var team in teams.Keys)
            {
                var gameObjects = teams[team].Entities.Select(x => x.gameObject).ToArray();
                var unitPool = new UnitPool(InitialCount);
                unitPool.InitPool(gameObjects, poolContainer);
                _pools.Add(team, unitPool);

                Create(teams[team].SpawnPoints[0], team, teams[team].UnitsContainer.transform);
                Create(teams[team].SpawnPoints[1], team, teams[team].UnitsContainer.transform);
            }
        }

        private void InitializeOnScene()
        {
            Entity[] entities = GameObject.FindObjectsOfType<Entity>();
            for (int i = 0, count = entities.Length; i < count; i++)
            {
                Entity entity = entities[i];
                entity.Initialize(_world);
                this.entities.Add(entity.Id, entity);
            }
        }

        public Entity Create(Vector3 position, TeamEnum team, Transform parent = null)
        {
            var obj = _pools[team].GetFromPool(position, parent);
            Entity entity = obj.GetComponent<Entity>();
            entity.Initialize(_world);
            entities.Add(entity.Id, entity);
            return entity;
        }

        public void Destroy(int id)
        {
            if (entities.Remove(id, out Entity entity))
            {
                entity.Dispose();
                entity.gameObject.SetActive(false); //todo: return to pool
            }
        }


        public Entity Get(int id)
        {
            return entities[id];
        }
    }

    public class TeamDescription
    {
        public Entity[] Entities { get; set; }

        public Vector3[] SpawnPoints { get; set; }

        public GameObject UnitsContainer { get; set; }
    }
   
}
