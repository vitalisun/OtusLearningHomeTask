using UnityEngine;
using Zenject;

public class Task2Installer : MonoInstaller
{
    [SerializeField] private ClickerView _clickerPrefab;
    private ClickerCharacterData[] _clickerCharacters;


    public override void InstallBindings()
    {
        Container.Bind<ClickerView>().FromInstance(_clickerPrefab).AsSingle();
    }
}
