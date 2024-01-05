using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace Assets.Homeworks.MVxPractice.Task3.Scripts
{
    public class Task3Installer : MonoInstaller
    {
        [SerializeField] private FightingSelectorView _fightingSelectorPrefab;

        public override void InstallBindings()
        {
            Container.Bind<FightingSelectorView>().FromInstance(_fightingSelectorPrefab).AsSingle();
        }
    }
}
