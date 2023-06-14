using System;
using UnityEngine;

namespace GamePlay
{
    public class PlayerAnimator : MonoBehaviour
    {
        private Animator _animator;
        private static readonly int IS_MOVE = Animator.StringToHash("IsMove");

        private void Start()
        {
            _animator = GetComponent<Animator>();
        }

        public void IdleAnimation()
        {
            _animator.SetBool(IS_MOVE, false);
        }

        public void MoveAnimation()
        {
            _animator.SetBool(IS_MOVE, true);
        }
    }
}