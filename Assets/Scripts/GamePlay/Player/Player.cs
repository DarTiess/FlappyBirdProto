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
        private ISaveEconomic _saveEconomic;
        private bool _isDead;

        public void Init(ILevelState levelState,
                         ILevelEvents levelEvents,
                         ITouchPad touchPad,
                         ISaveEconomic saveEconomic, 
                         PlayerConfig playerConfig)
        { 
            _levelState = levelState;
            _saveEconomic = saveEconomic;
            _levelEvents = levelEvents;
            _levelEvents.PlayGame += OnStartingPlayGame;
            _levelEvents.StopGame += OnPauseGame;
           
          
            _playerMovement=GetComponent<PlayerMovement>();
            _playerAnimator = GetComponent<PlayerAnimator>();
            _playerMovement.Init(touchPad, playerConfig, _playerAnimator);
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
             _playerAnimator.DieAnimation();
        }

        private void OnStartingPlayGame()
        {
             _playerMovement.OnStartingPlayGame();
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
                _saveEconomic.SaveValue();
            }
           
        }
    }
}
