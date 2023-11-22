using UnityEngine;

namespace Assets.Scripts.Components
{
    public sealed class TeamComponent : MonoBehaviour
    {
        [field:SerializeField]
        public bool IsPlayer { get; set; }
    }
}