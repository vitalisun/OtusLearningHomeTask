using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Assets.Game.Scripts.Bullet;
using Assets.Game.Scripts.Player;
using Assets.Game.Scripts.System;
using Assets.Game.Scripts.Zombi;
using UnityEngine;
using Zenject;
using static Assets.Game.Scripts.GameManager.Listeners;

public class SceneInstaller : MonoInstaller
{
    [SerializeField] private Player _player;
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private AudioSource _source;
    [SerializeField] private Zombi _zombi;

    public override void InstallBindings()
    {
        Container.Bind<Player>().FromInstance(_player).AsSingle();
        Container.Bind<AudioSource>().FromInstance(_source).AsSingle();
        Container.Bind<InputController>().AsSingle();

        Container.Bind<Bullet>().FromInstance(_bulletPrefab).AsSingle();
        Container.Bind<BulletPool>().FromInstance(new BulletPool(10)).AsSingle();

        Container.Bind<Zombi>().FromInstance(_zombi).AsSingle();
        Container.Bind<ZombiPool>().FromInstance(new ZombiPool(10)).AsSingle();
    }
}
