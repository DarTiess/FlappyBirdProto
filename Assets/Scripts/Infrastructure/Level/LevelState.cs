using System;
using UnityEngine;

namespace Infrastructure.Level
{
    public class LevelState : ILevelState, ILevelEvents
    {
        public event Action LevelStart;
        public event Action LevelWin;
        public event Action LateWin;
        public event Action LevelLost;
        public event Action LateLost;
        public event Action PlayGame;
        public event Action StopGame;
        public event Action<Level> ChangeLevelSetting;
        
        private float _timeWaitLose;
        private float _timeWaitWin;
        private bool _onPaused;
        private ILevelChangeData _levelChangeData;
        public LevelState(ILevelChangeData levelChangeData, float timeWaitLose, float timeWaitWin)
        {
            _levelChangeData = levelChangeData;
            _timeWaitLose = timeWaitLose;
            _timeWaitWin = timeWaitWin;

            _levelChangeData.ChangeLevelData += OnChangeLevelSettings;
            OnLevelStart();
        }

        private void OnChangeLevelSettings(Level levelSetting)
        {
            ChangeLevelSetting?.Invoke(levelSetting);
        }

        public void OnLevelStart()
        {
            LevelStart?.Invoke();
        }

        public void PauseGame()
        {
            if (!_onPaused)
            {
                StopGame?.Invoke();
                _onPaused = true;
            }
            else
            {
                OnPlayGame();
                _onPaused = false;
            }
        }

        public void OnPlayGame()
        {
            PlayGame?.Invoke();
        }

        public void OnLevelLost()
        {
            LevelLost?.Invoke();
            OnLateLost();
        }

        private void OnLateLost()
        {
            while (_timeWaitLose>0)
            {
                _timeWaitLose -= Time.deltaTime;
            }
            LateLost?.Invoke();
        }

        public void OnLevelWin()
        {
            LevelWin?.Invoke();
            OnLateWin();
        }

        private void OnLateWin()
        {
            while (_timeWaitWin>0)
            {
                _timeWaitWin -= Time.deltaTime;
            }
            LateWin?.Invoke();
        }

    }
}
