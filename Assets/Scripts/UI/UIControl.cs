using System;
using Infrastructure;
using Infrastructure.Level;
using UI.Touch;
using UI.UIPanels;
using UnityEngine;

namespace UI
{
    public class UIControl : MonoBehaviour, ITouchPad
    {
        [Header("Panels")]
        [SerializeField] private StartMenu _panelMenu;
        [SerializeField] private GamePanel _panelInGame;
        [SerializeField] private WinPanel _panelWin;  
        [SerializeField] private LostPanel _panelLost;
        [SerializeField] private TouchPad _touchPad;
        [SerializeField] private HeaderPanel _headerPanel;

        public event Action ClickedTouch;
        
        private ILevelManager _levelManager;
        private ILevelEvents _levelEvents;
        private ILevelLoader _levelLoader;
        private ICoinsEvents _coinsEvents;


        public void Init(ILevelManager levManager,
                         ILevelEvents levelEvents,
                         ILevelLoader levelLoader,
                         ICoinsEvents coinsEvents)
        {
            _levelManager = levManager;
            _levelEvents = levelEvents;
            _levelLoader = levelLoader;
            _coinsEvents = coinsEvents;
     
            _levelEvents.LevelStart += OnLevelStart;
            _levelEvents.LateWin += OnLevelWin; 
            _levelEvents.LateLost += OnLevelLost;
            _coinsEvents.ChangeCoins += OnChangeCoins;

            _panelMenu.ClickedPanel += OnPlayGame;
            _panelLost.ClickedPanel += RestartGame;
            _panelInGame.ClickedPanel += OnPauseGame;
            _panelWin.ClickedPanel += LoadNextLevel;
            _touchPad.ClickedTouch += OnClickedTouch;
            OnLevelStart();
        }

        private void OnChangeCoins(int coins)
        {
            _headerPanel.OnChangeCoinsValue(coins);
        }

        private void OnClickedTouch()
        {
            ClickedTouch?.Invoke();
        }

        private void OnDisable()
        {
            _levelEvents.LevelStart -= OnLevelStart;
            _levelEvents.LateWin -= OnLevelWin; 
            _levelEvents.LateLost -= OnLevelLost;
            _coinsEvents.ChangeCoins -= OnChangeCoins;

            _panelMenu.ClickedPanel -= OnPlayGame;
            _panelLost.ClickedPanel -= RestartGame;
            _panelInGame.ClickedPanel -= OnPauseGame;
            _panelWin.ClickedPanel -= LoadNextLevel;
            _touchPad.ClickedTouch -= OnClickedTouch;
        }

        private void OnLevelStart()      
        {   
            HideAllPanels();
            _headerPanel.InitCoinsValue(_coinsEvents.GetCoinsValue());
            _panelMenu.Show();
        }

        private void OnLevelWin()      
        {    
            Debug.Log("Level Win"); 
            HideAllPanels();
            _panelWin.Show();  
        }

        private void OnLevelLost()           
        {                                                     
            Debug.Log("Level Lost");  
            HideAllPanels();
            _panelLost.Show();
        }

        private void OnPauseGame()
        {
            _levelManager.PauseGame();
        }

        private void OnPlayGame()
        { 
            _levelManager.OnPlayGame();
            HideAllPanels(); 
            _panelInGame.Show();         
        }

        private void LoadNextLevel()
        {
            _levelLoader.LoadNextLevel();
        }

        private void RestartGame()
        {
            _levelLoader.RestartScene();
        }

        private void HideAllPanels()
        {
            _panelMenu.Hide();
            _panelLost.Hide();
            _panelWin.Hide();
            _panelInGame.Hide();
        }
    }
}
