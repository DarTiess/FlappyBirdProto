using System;
using UnityEngine;

//using GameAnalyticsSDK;

namespace Infrastructure.Level
{
    public class LevelManager : ILevelManager, ILevelEvents
    {
        public event Action LevelStart;
        public event Action LevelWin;
        public event Action LateWin;
        public event Action LevelLost;
        public event Action LateLost;
        public event Action PlayGame;
        public event Action StopGame;
        
        private float _timeWaitLose;
        private float _timeWaitWin;
        private bool _onPaused;
        public LevelManager(float timeWaitLose, float timeWaitWin)
        {
            _timeWaitLose = timeWaitLose;
            _timeWaitWin = timeWaitWin;
            OnLevelStart();
        }
    
        public void OnLevelStart()
        {
            LevelStart?.Invoke();
            //GameAnalytics.NewProgressionEvent(GAProgressionStatus.Start, LevelLoader.NumLevel);
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

            //GameAnalytics.NewProgressionEvent(GAProgressionStatus.Fail,LevelLoader.NumLevel);

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

            //GameAnalytics.NewProgressionEvent(GAProgressionStatus.Complete,LevelLoader.NumLevel); 

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
