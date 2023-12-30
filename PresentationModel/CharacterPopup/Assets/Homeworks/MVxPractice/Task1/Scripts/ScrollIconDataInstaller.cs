using Assets.Homeworks.MVxPractice.Task1.Scripts.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
