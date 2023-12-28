using System.Collections;
using System.Collections.Generic;
using Assets.Homeworks.PresentationModel.Scripts;
using Assets.Homeworks.PresentationModel.Scripts.Models;
using Lessons.Architecture.PM;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class SceneInstaller : MonoInstaller
{
    [SerializeField]
    private UserInfoData _userInfoData;

    [SerializeField] private GameObject _popupPrefab;

    public override void InstallBindings()
    {
        Container.Bind<GameObject>().WithId("PopupPrefab").FromInstance(_popupPrefab).AsSingle();

        BindDataDependencies();
    }

    private void BindDataDependencies()
    {
        Container.Bind<UserInfoModelFactory>().AsSingle();
        Container.BindInstance(_userInfoData).AsSingle();
    }

}
