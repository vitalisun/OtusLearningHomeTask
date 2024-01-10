using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.SaveSystem
{
    public class SaveLoadManager : MonoBehaviour
    {
        private ISaveLoader[] _saveLoaders;
        private IGameRepository _gameRepository;

        [Inject]
        public void Construct(GameRepository gameRepository, ISaveLoader[] saveLoaders)
        {
            _gameRepository = gameRepository;
            _saveLoaders = saveLoaders;
        }

        [Button]
        public void LoadGame()
        {
            _gameRepository.LoadState();

            var sceneContext = FindObjectOfType<SceneContext>();

            foreach (var saveLoader in _saveLoaders)
            {
                saveLoader.LoadGame(_gameRepository, sceneContext);
            }
        }

        [Button]
        public void SaveGame()
        {
            var sceneContext = FindObjectOfType<SceneContext>();

            foreach (var saveLoader in _saveLoaders)
            {
                saveLoader.SaveGame(_gameRepository,sceneContext);
            }

            _gameRepository.SaveState();
        }
    }
}
