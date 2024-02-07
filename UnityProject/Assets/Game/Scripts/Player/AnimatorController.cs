using UnityEngine;

namespace Assets.Game.Scripts.Player
{
    public class AnimatorController : MonoBehaviour
    {
        [SerializeField]
        private Player _player;
        private Animator _animator;

        public void Awake()
        {
            _animator = GetComponentInChildren<Animator>();
        }

        public void Update()
        {
            CalculateMovementAnimation();
        }

        private void CalculateMovementAnimation()
        {
            Vector3 localMovementDirection = _player.LocalMovementDirection.Value;
            float moveX = localMovementDirection.x;
            float moveZ = localMovementDirection.z;

            bool isMoving = _player.MoveDirection.Value.magnitude > 0.01f;

            _animator.SetFloat("Horizontal", isMoving ? moveX : 0, 0.1f, Time.deltaTime);
            _animator.SetFloat("Vertical", isMoving ? moveZ : 0, 0.1f, Time.deltaTime);
        }
    }
}
