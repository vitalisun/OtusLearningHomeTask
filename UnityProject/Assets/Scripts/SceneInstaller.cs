using System.Collections.Generic;
using Assets.Scripts.SaveSystem;
using GameEngine;
using UnityEngine;
using Zenject;

public class SceneInstaller : MonoInstaller
{
    [SerializeField] private Transform _unitsContainer;
    public List<Unit> UnitPrefabs;

    public override void InstallBindings()
    {
        Container.Bind<UnitManager>().FromInstance(new UnitManager(_unitsContainer)).AsSingle();
        Container.Bind<ResourceService>().FromInstance(new ResourceService()).AsSingle();

        Container.Bind<List<Unit>>().FromInstance(UnitPrefabs).AsSingle();
        Container.Bind<GameRepository>().AsSingle();
        Container.Bind<SaveLoadManager>().AsSingle();

        // Binding implementations of ISaveLoader
        Container.BindInterfacesTo<UnitsSaveLoader>().AsSingle().NonLazy();
        Container.BindInterfacesTo<ResourcesSaveLoader>().AsSingle().NonLazy();
    }
}