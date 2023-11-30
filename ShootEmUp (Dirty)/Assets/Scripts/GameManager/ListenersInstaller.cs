using System.Linq;
using Assets.Scripts.GameManager.GameSystem.Interfaces;
using UnityEngine;

namespace Assets.Scripts.GameManager
{
    [RequireComponent(typeof(GameSystem.GameManager))]
    public class ListenersInstaller : MonoBehaviour, IInstaller
    {
        public GameObject[] AdditionalListenerObjects;

        public void Install()
        {
            var gameManager = GetComponent<GameSystem.GameManager>();
            var listeners = GetComponentsInChildren<Listeners.IGameListener>(true);

            var additionalListeners = AdditionalListenerObjects
                .SelectMany(obj => obj.GetComponentsInChildren<Listeners.IGameListener>(true));

            listeners = listeners.Concat(additionalListeners).ToArray();

            foreach (var listener in listeners)
            {
                gameManager.AddListener(listener);
            }

        }
    }
}