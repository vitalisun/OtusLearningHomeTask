using Assets.Homeworks.PresentationModel.Scripts.Models;
using UnityEngine;
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
