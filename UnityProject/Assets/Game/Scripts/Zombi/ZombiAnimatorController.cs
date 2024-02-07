using UnityEngine;

namespace Assets.Game.Scripts.Zombi
{
    public class ZombiAnimatorController : MonoBehaviour
    {
        [SerializeField] private Zombi _zombi;
        private Animator _animator;

        public void Awake()
        {
            _animator = GetComponentInChildren<Animator>();
        }

        public void Update()
        {
            _animator.SetInteger("State", (int)_zombi.State.Value);
        }
    }
}
