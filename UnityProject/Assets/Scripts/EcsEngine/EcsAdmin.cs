using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts;
using Assets.Scripts.Content;
using Assets.Scripts.EcsEngine.Systems;
using EcsEngine.Components;
using EcsEngine.Systems;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using Leopotam.EcsLite.Entities;
using Leopotam.EcsLite.ExtendedSystems;
using Leopotam.EcsLite.Helpers;
using Sirenix.OdinInspector;
using UnityEngine;

namespace EcsEngine
{
    public sealed class EcsAdmin : MonoBehaviour
    {
        public static EcsAdmin Instance { get; private set; }

        private EcsWorld _world;
        private EcsWorld _events;
        private IEcsSystems _systems;
        private UnitManager _unitManager;

        public List<Entity> _redTeam;
        public List<Entity> _blueTeam;
        public List<Transform> _redSpawnPoints;
        public List<Transform> _blueSpawnPoints;

        [SerializeField] private Transform _poolContainer;
        [SerializeField] private GameObject _unitsContainer;

        public EcsEntityBuilder CreateEntity(string worldName = null)
        {
            return new EcsEntityBuilder(_systems.GetWorld(worldName));
        }

        public EcsWorld GetWorld(string worldName = null)
        {
            return worldName switch
            {
                null => _world,
                EcsWorlds.Events => _events,
                _ => throw new Exception($"World with name {worldName} is not found!")
            };
        }

        private void Awake()
        {
            Instance = this;

            _unitManager = new UnitManager();

            _world = new EcsWorld();
            _events = new EcsWorld();
            _systems = new EcsSystems(_world);

            _systems.AddWorld(_events, EcsWorlds.Events);

            _systems

                //Game Logic:
                .Add(new FindTargetSystem())
                .Add(new AttackSystem())
                .Add(new TakeDamageSystem())
                .Add(new UnitDestroySystem())

                //Game Listeners:

                //View:
                .Add(new TransformViewSynchronizer())

                //Editor:
#if UNITY_EDITOR
                .Add(new Leopotam.EcsLite.UnityEditor.EcsWorldDebugSystem())
                .Add(new Leopotam.EcsLite.UnityEditor.EcsWorldDebugSystem(EcsWorlds.Events));
#endif
            Debug.Log("EcsAdmin Awake");
            //Clean Up:
        }

        private void Start()
        {
            var prefabs = new Dictionary<TeamEnum, TeamDescription>
            {
                {
                    TeamEnum.Red,
                    new TeamDescription
                    {
                        Entities = _redTeam.ToArray(),
                        SpawnPoints = _redSpawnPoints.Select(x=>x.position).ToArray(),
                        UnitsContainer = _unitsContainer
                    }
                },
                {
                    TeamEnum.Blue,
                    new TeamDescription
                    {
                        Entities = _blueTeam.ToArray(),
                        SpawnPoints = _blueSpawnPoints.Select(x=>x.position).ToArray(),
                        UnitsContainer = _unitsContainer
                    }
                }
            };

            _unitManager.Initialize(_world, prefabs, _poolContainer);
            _systems.Inject(_unitManager);
            _systems.Init();
        }

        private void Update()
        {
            _systems?.Run();
        }

        private void OnDestroy()
        {
            if (_systems != null)
            {
                // list of custom worlds will be cleared
                // during IEcsSystems.Destroy(). so, you
                // need to save it here if you need.
                _systems.Destroy();
                _systems = null;
            }

            // cleanup custom worlds here.

            // cleanup default world.
            if (_world != null)
            {
                _world.Destroy();
                _world = null;
            }
        }
    }
}