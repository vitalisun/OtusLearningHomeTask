using UnityEngine;
using Zenject;

namespace Assets.Game.Scripts
{
    public class FollowPlayer : MonoBehaviour
    {
        private Player.Player _player;
        public Vector3 Offset;

        [Inject]
        public void Construct(Player.Player player)
        {
            _player = player;
        }

        private void Awake()
        {
            Offset = new Vector3(0, 13, -9);
            transform.rotation = Quaternion.Euler(50, 0, 0);
        }

        void LateUpdate()
        {
            transform.position = _player.transform.position + Offset;
        }
    }
}
