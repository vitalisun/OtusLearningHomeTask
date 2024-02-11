using System.Linq;
using UnityEngine;

namespace Assets.Game.Scripts.GameManager
{
    [RequireComponent(typeof(GameManager))]
    public class ListenersInstaller : MonoBehaviour
    {
        public GameObject[] AdditionalListenerObjects;

        private void Awake()
        {
            var gameManager = GetComponent<GameManager>();
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
