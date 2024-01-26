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
        private SceneContext _sceneContext;

        [Inject]
        public void Construct(GameRepository gameRepository, ISaveLoader[] saveLoaders, SceneContext sceneContext)
        {
            _sceneContext = sceneContext;
            _gameRepository = gameRepository;
            _saveLoaders = saveLoaders;
        }

        [Button]
        public void LoadGame()
        {
            _gameRepository.LoadState();

            foreach (var saveLoader in _saveLoaders)
            {
                saveLoader.LoadGame(_gameRepository, _sceneContext.Container);
            }
        }

        [Button]
        public void SaveGame()
        {

            foreach (var saveLoader in _saveLoaders)
            {
                saveLoader.SaveGame(_gameRepository, _sceneContext.Container);
            }

            _gameRepository.SaveState();
        }
    }
}
