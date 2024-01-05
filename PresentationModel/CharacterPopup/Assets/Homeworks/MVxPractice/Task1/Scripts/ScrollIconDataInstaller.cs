using Assets.Homeworks.MVxPractice.Task1.Scripts.Data;
using UnityEngine;
using Zenject;

namespace Assets.Homeworks.MVxPractice.Task1.Scripts
{
    [CreateAssetMenu(fileName = "ScrollIconDataInstaller", menuName = "Installers/ScrollIconDataInstaller")]
    public class ScrollIconDataInstaller : ScriptableObjectInstaller<ScrollIconDataInstaller>
    {
        public ScrollIconData[] ScrollIconDataArray;

        public override void InstallBindings()
        {
            Container.BindInstance(ScrollIconDataArray).AsSingle();
        }
    }

}
