using UnityEngine;

namespace Assets.Scripts.Components
{
    public sealed class TeamComponent : MonoBehaviour
    {
        public bool IsPlayer
        {
            get { return _isPlayer; }
        }

        [SerializeField]
        private bool _isPlayer;
    }
}