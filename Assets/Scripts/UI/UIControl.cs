using System;
using Infrastructure;
using Infrastructure.Coins;
using Infrastructure.Level;
using UI.Touch;
using UI.UIPanels;
using UnityEngine;

namespace UI
{
    public interface ISoundUIEvent
    {
        event Action<bool> ChangeSoundState;
    }
    public class UIControl : MonoBehaviour, ITouchPad, ISoundUIEvent
    {
        [Header("Panels")]
        [SerializeField] private StartMenu _panelMenu;
        [SerializeField] private GamePanel _panelInGame;
        [SerializeField] private WinPanel _panelWin;  
        [SerializeField] private LostPanel _panelLost;
        [SerializeField] private TouchPad _touchPad;
        [SerializeField] private HeaderPanel _headerPanel;
        [SerializeField] private SettingsPanel _settingsPanel;

        public event Action ClickedTouch;
        public event Action<bool> ChangeSoundState; 

        private ILevelState _levelState;
        private ILevelEvents _levelEvents;
        private ISceneLoader _sceneLoader;
        private ICoinsEvents _coinsEvents;


        public void Init(ILevelState levState,
                         ILevelEvents levelEvents,
                         ISceneLoader sceneLoader,
                         ICoinsEvents coinsEvents,
                         bool soundState)
        {
            _levelState = levState;
            _levelEvents = levelEvents;
            _sceneLoader = sceneLoader;
            _coinsEvents = coinsEvents;
            _settingsPanel.SetSoundState(soundState);
     
            _levelEvents.LevelStart += OnLevelStart;
            _levelEvents.LateWin += OnLevelWin; 
            _levelEvents.LateLost += OnLevelLost;
            _coinsEvents.ChangeCoins += OnChangeCoins;

            _panelMenu.ClickedPanel += OnPlayGame;
            _panelMenu.ClickedSettingsButton += OnOpenSettings;
            _panelLost.ClickedPanel += RestartGame;
            _panelWin.ClickedPanel += LoadNextLevel;
          
            _touchPad.ClickedTouch += OnClickedTouch;
            _settingsPanel.ChangeSound += OnChangeSoundState;
            OnLevelStart();
        }

        private void OnChangeSoundState(bool state)
        {
            ChangeSoundState?.Invoke(state);
        }

        private void OnDisable()
        {
            _levelEvents.LevelStart -= OnLevelStart;
            _levelEvents.LateWin -= OnLevelWin; 
            _levelEvents.LateLost -= OnLevelLost;
            _coinsEvents.ChangeCoins -= OnChangeCoins;

            _panelMenu.ClickedPanel -= OnPlayGame;
            _panelMenu.ClickedSettingsButton -= OnOpenSettings;
            _panelLost.ClickedPanel -= RestartGame;
            _panelWin.ClickedPanel -= LoadNextLevel;
          
            _touchPad.ClickedTouch -= OnClickedTouch;
            _settingsPanel.ChangeSound -= OnChangeSoundState;
        }

        private void OnOpenSettings()
        {
            _settingsPanel.Show();
        }

        private void OnChangeCoins(int coins)
        {
            _headerPanel.OnChangeCoinsValue(coins);
        }

        private void OnClickedTouch()
        {
            ClickedTouch?.Invoke();
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

        private void OnPlayGame()
        { 
            _levelState.OnPlayGame();
            HideAllPanels(); 
            _panelInGame.Show();         
        }

        private void LoadNextLevel()
        {
            _sceneLoader.LoadNextScene();
        }

        private void RestartGame()
        {
            _sceneLoader.RestartScene();
        }

        private void HideAllPanels()
        {
            _panelMenu.Hide();
            _panelLost.Hide();
            _panelWin.Hide();
            _panelInGame.Hide();
            _settingsPanel.Hide();
        }
    }
}
