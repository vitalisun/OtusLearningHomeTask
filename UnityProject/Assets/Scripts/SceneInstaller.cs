using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Core;
using Assets.Scripts.Core.Handlers;
using Assets.Scripts.Core.Pipeline.Turn;
using UnityEngine;
using Zenject;
using Zenject.Asteroids;

public class SceneInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        UnityEngine.Debug.Log("SceneInstaller.InstallBindings");

        Container.Bind<EventBus>().AsSingle().NonLazy();


    }
}
