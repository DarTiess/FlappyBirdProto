using System;
using Infrastructure;
using Infrastructure.Level;
using UI.Touch;
using UnityEngine;

namespace GamePlay
{
    [RequireComponent(typeof(PlayerMovement))]
    [RequireComponent(typeof(PlayerAnimator))]
    [RequireComponent(typeof(PlayerSounds))]
    public class Player : MonoBehaviour
    {
        private PlayerMovement _playerMovement;
        private PlayerAnimator _playerAnimator;
        private PlayerSounds _playerSounds;
        private ILevelManager _levelManager;
        private ILevelEvents _levelEvents;
        private IAddCoins _addCoins;
        private bool _isDead;

        public void Init(ILevelManager levelManager,
                         ILevelEvents levelEvents,
                         ITouchPad touchPad,
                         IAddCoins addCoins, 
                         float upForce)
        { 
            _levelManager = levelManager;
            _addCoins = addCoins;
            _levelEvents = levelEvents;
            _levelEvents.PlayGame += OnStartingPlayGame;
           
          
            _playerMovement=GetComponent<PlayerMovement>();
            _playerAnimator = GetComponent<PlayerAnimator>();
            _playerSounds = GetComponent<PlayerSounds>();
            _playerMovement.Init(touchPad,_playerSounds, upForce);
        }

        private void OnDisable()
        {
            _levelEvents.PlayGame -= OnStartingPlayGame;
        }

        private void OnLevelLost()
        {
             _playerMovement.GameOver();
             _playerAnimator.IdleAnimation();
             _playerSounds.PlayLostSound();
        }

        private void OnStartingPlayGame()
        {
             _playerMovement.OnStartingPlayGame();
             _playerAnimator.MoveAnimation();
        }

        private void OnCollisionEnter2D(Collision2D col)
        {
            if (col.gameObject.TryGetComponent(out Blocks block))
            { 
                _isDead = true;
                _levelManager.OnLevelLost();
                OnLevelLost();
            }
        }

        private void OnTriggerExit2D(Collider2D col)
        {
            if (!_isDead && col.TryGetComponent(out Blocks blocks))
            {
                _addCoins.AddCoins();
                _playerSounds.PlayAddCoin();
            }
           
        }
    }
}
