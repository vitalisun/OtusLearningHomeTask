using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    public class AnimatorController : MonoBehaviour
    {
        [SerializeField]
        private Player _player;
        private Animator _animator;

        public void Awake()
        {
            _animator = GetComponentInChildren<Animator>();
            _animator.SetInteger("State", 0);
        }

        public void Update()
        {
            _animator.SetInteger("State", GetState());
        }

        private int GetState()
        {
            var state = 0;
            if (_player.MoveDirection.Value == Vector3.forward)
            {
                state = 1;
            }
            
            if (_player.MoveDirection.Value == Vector3.back)
            {
                state = 2;
            }
            
            if (_player.MoveDirection.Value == Vector3.left)
            {
                state = 3;
            }
            
            if (_player.MoveDirection.Value == Vector3.right)
            {
                state = 4;
            }
            return state;
        }
    }
}
