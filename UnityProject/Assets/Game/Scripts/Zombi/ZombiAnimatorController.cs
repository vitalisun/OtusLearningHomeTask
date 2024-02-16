using Assets.Game.Scripts.Shared;
using UnityEngine;

namespace Assets.Game.Scripts.Zombi
{
    public class ZombiAnimatorController : MonoBehaviour
    {
        private Animator _animator;
        private AnimatorEventDispatcher _animatorEventDispatcher;
        private Zombi _zombi;

        private void Awake()
        {
            _zombi = GetComponent<Zombi>();
            _animator = GetComponentInChildren<Animator>();
            _animatorEventDispatcher = GetComponentInChildren<AnimatorEventDispatcher>();
        }

        private void Update()
        {
            _animator.SetInteger("State", (int)_zombi.State.Value);
        }

        private void OnEnable()
        {
            _animatorEventDispatcher.OnEventReceived += OnEventReceivedHandler;
        }

        private void OnDisable()
        {
            _animatorEventDispatcher.OnEventReceived -= OnEventReceivedHandler;
        }

        private void OnEventReceivedHandler(string key)
        {
            if (key == "ZombiAttack")
            {
                _zombi.AttackRequest.Invoke();
            }
        }
    }
}
