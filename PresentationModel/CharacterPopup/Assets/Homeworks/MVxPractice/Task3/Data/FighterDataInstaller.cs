using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "FighterDataInstaller", menuName = "Installers/FighterDataInstaller")]
public class FighterDataInstaller : ScriptableObjectInstaller<FighterDataInstaller>
{
    [SerializeField] private FighterData[] _fighterData;

    public override void InstallBindings()
    {
        Container.BindInstance(_fighterData);
    }
}
