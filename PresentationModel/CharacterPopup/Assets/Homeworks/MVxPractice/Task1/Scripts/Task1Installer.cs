using Assets.Homeworks.MVxPractice.Task1.Scripts.Data;
using UnityEngine;
using Zenject;

public class Task1Installer : MonoInstaller
{
    [SerializeField] private CharacterSelector _characterSelectorPrefab;
    [SerializeField] private ScrollIconData[] _scrollIconDataList;

    public override void InstallBindings()
    {
        Container.Bind<CharacterSelector>().FromInstance(_characterSelectorPrefab).AsSingle();
    }
}
