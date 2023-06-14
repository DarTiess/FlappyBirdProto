using System;
using Infrastructure;
using Infrastructure.Coins;
using Infrastructure.Level;
using UI.Touch;
using UnityEngine;

namespace GamePlay
{
    [RequireComponent(typeof(PlayerMovement))]
    [RequireComponent(typeof(PlayerAnimator))]
    public class Player : MonoBehaviour
    {
        private PlayerMovement _playerMovement;
        private PlayerAnimator _playerAnimator;
        private ILevelState _levelState;
        private ILevelEvents _levelEvents;
        private IAddCoins _addCoins;
        private bool _isDead;

        public void Init(ILevelState levelState,
                         ILevelEvents levelEvents,
                         ITouchPad touchPad,
                         IAddCoins addCoins, 
                         float upForce)
        { 
            _levelState = levelState;
            _addCoins = addCoins;
            _levelEvents = levelEvents;
            _levelEvents.PlayGame += OnStartingPlayGame;
            _levelEvents.StopGame += OnPauseGame;
           
          
            _playerMovement=GetComponent<PlayerMovement>();
            _playerAnimator = GetComponent<PlayerAnimator>();
            _playerMovement.Init(touchPad, upForce);
        }

        private void OnDisable()
        {
            _levelEvents.PlayGame -= OnStartingPlayGame;
            _levelEvents.StopGame -= OnPauseGame;
        }

        private void OnPauseGame()
        {
            _playerMovement.GameStop();
        }

        private void OnLevelLost()
        {
             _playerMovement.GameStop();
             _playerAnimator.IdleAnimation();
        }

        private void OnStartingPlayGame()
        {
             _playerMovement.OnStartingPlayGame();
             _playerAnimator.MoveAnimation();
        }

        private void OnCollisionEnter2D(Collision2D col)
        {
            if (col.gameObject.TryGetComponent<Blocks>(out Blocks block))
            { 
                _isDead = true;
                _levelState.OnLevelLost();
                OnLevelLost();
            }
        }

        private void OnTriggerExit2D(Collider2D col)
        {
            if (!_isDead && col.TryGetComponent<Blocks>(out Blocks blocks))
            {
                _addCoins.AddCoins();
            }
           
        }
    }
}
