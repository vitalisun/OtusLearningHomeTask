using System.Collections.Generic;
using Assets.Scripts.SaveSystem;
using GameEngine;
using UnityEngine;
using Zenject;

public class SceneInstaller : MonoInstaller
{
    [SerializeField] private Transform _unitsContainer;

    [SerializeField] private Spawner _spawner;

    public override void InstallBindings()
    {
        Container.Bind<UnitManager>().FromInstance(new UnitManager(_unitsContainer, _spawner)).AsSingle();
        Container.Bind<ResourceService>().FromInstance(new ResourceService()).AsSingle();

        Container.Bind<GameRepository>().AsSingle();
        Container.Bind<SaveLoadManager>().AsSingle();

        // Binding implementations of ISaveLoader
        Container.BindInterfacesTo<UnitsSaveLoader>().AsCached().NonLazy();
        Container.BindInterfacesTo<ResourcesSaveLoader>().AsCached().NonLazy();
        Container.Bind<Spawner>().FromComponentInHierarchy().AsCached().NonLazy();
    }
}