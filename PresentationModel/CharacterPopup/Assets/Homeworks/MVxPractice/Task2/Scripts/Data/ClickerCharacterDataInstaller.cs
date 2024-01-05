using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "ClickerCharacterDataInstaller", menuName = "Installers/ClickerCharacterDataInstaller")]
public class ClickerCharacterDataInstaller : ScriptableObjectInstaller<ClickerCharacterDataInstaller>
{
    [SerializeField] private ClickerCharacterData[] _clickerCharacterData;

    public override void InstallBindings()
    {
        Container.BindInstance(_clickerCharacterData);
    }
}