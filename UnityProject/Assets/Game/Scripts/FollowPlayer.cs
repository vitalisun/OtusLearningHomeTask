using UnityEngine;

namespace Assets.Game.Scripts
{
    public class FollowPlayer : MonoBehaviour
    {
        [SerializeField]
        private Transform player;
        public Vector3 offset;
   

        private void Awake()
        {
            offset = new Vector3(0, 13, -9);
            transform.rotation = Quaternion.Euler(50, 0, 0);
        }

        void LateUpdate()
        {
            transform.position = player.position + offset;
        }
    }
}
