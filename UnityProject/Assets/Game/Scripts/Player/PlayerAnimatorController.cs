using UnityEngine;
using Zenject;

namespace Assets.Game.Scripts.Player
{
    public class PlayerAnimatorController : MonoBehaviour
    {
        private Player _player;
        private Animator _animator;

        [Inject]
        public void Construct(Player player)
        {
            _player = player;
        }

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
            var localMovementDirection = _player.LocalMovementDirection.Value;
            var moveX = localMovementDirection.x;
            var moveZ = localMovementDirection.z;

            var isMoving = _player.MoveDirection.Value.magnitude > 0.01f;

            _animator.SetFloat("Horizontal", isMoving ? moveX : 0, 0.1f, Time.deltaTime);
            _animator.SetFloat("Vertical", isMoving ? moveZ : 0, 0.1f, Time.deltaTime);
        }
    }
}
