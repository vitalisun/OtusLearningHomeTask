using UnityEngine;

namespace Assets.Scripts.DI._1
{
    public sealed class DependencyAssembler : MonoBehaviour
    {
        [SerializeField]
        private MonoBehaviour[] targets;

        private void Awake()
        {
            foreach (var target in this.targets)
            {
                DependencyInjector.Inject(target);
            }
        }
    }
}