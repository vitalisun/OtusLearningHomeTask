using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Pipeline.Turn;
using UnityEngine;
using Zenject;
using Zenject.Asteroids;

public class SceneInstaller : MonoInstaller
{
    public override void InstallBindings()
    {

        UnityEngine.Debug.Log("SceneInstaller.InstallBindings");

        Container.Bind<TurnPipeline>().AsSingle().NonLazy();
        Container.BindInterfacesAndSelfTo<TurnPipelineInstaller>().AsSingle().NonLazy();
    }
}
