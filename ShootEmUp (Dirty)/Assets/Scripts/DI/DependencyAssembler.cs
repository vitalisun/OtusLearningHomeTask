using UnityEngine;

namespace Assets.Scripts.DI
{
    public sealed class DependencyAssembler : MonoBehaviour
    {
        [SerializeField]
        private ServiceLocator _serviceLocator;

        private void Start()
        {
            GameObject[] gameObjects = this.gameObject.scene.GetRootGameObjects();

            foreach (var go in gameObjects)
            {
                this.Inject(go.transform);
            }
        }

        private void Inject(Transform targetTransform)
        {
            var targets = targetTransform.GetComponents<MonoBehaviour>();
            foreach (var target in targets)
            {
                DependencyInjector.Inject(target, _serviceLocator);
            }

            foreach (Transform child in targetTransform)
            {
                this.Inject(child);
            }
        }
    }
}