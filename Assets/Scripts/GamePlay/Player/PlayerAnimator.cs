using System;
using UnityEngine;

namespace GamePlay
{
    [RequireComponent(typeof(Animator))]
    public class PlayerAnimator : MonoBehaviour, IMoveAnimation
    {
        private Animator _animator;
        private static readonly int MOVE = Animator.StringToHash("Move");
        private static readonly int DIE = Animator.StringToHash("Die");

        private void Start()
        {
            _animator = GetComponent<Animator>();
        }
        
        public void MoveAnimation()
        {
            _animator.SetTrigger(MOVE);
        }
        public void DieAnimation()
        {
            _animator.SetTrigger(DIE);
        }
    }
}