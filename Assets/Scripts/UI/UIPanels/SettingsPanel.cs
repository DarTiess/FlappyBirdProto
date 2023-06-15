using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI.UIPanels
{
    public class SettingsPanel : MonoBehaviour
    {
        [SerializeField] private Button continueButton;
        [Header("Sound Settings")]
        [SerializeField] private Button soundButton;
        [SerializeField] private Image soundOffImage;
        [Header("Levels Settings")]
        [SerializeField] private Button minusLevelButton;
        [SerializeField] private Button plusLevelButton;
        [SerializeField] private Text levelText;

        public event Action<bool> ChangeSound;
        public event Action<int> ChangeLevel;
        private bool _soundON=true;
        private int _levelNumber;
        private int _maxLevel;

        private void Start()
        {
            continueButton.onClick.AddListener(Hide);
            soundButton.onClick.AddListener(SwitchSound);
            minusLevelButton.onClick.AddListener(MinusLevel);
            plusLevelButton.onClick.AddListener(PlusLevel);
        }

        private void PlusLevel()
        {
            if (_levelNumber <= _maxLevel)
            {
                _levelNumber += 1;
                levelText.text = _levelNumber.ToString();
                ChangeLevel?.Invoke(_levelNumber-1);
            }
           
            
        }

        private void MinusLevel()
        {
            if (_levelNumber > 0)
            {
                _levelNumber -= 1;
                levelText.text = _levelNumber.ToString();
                ChangeLevel?.Invoke(_levelNumber-1);
            }
            
        }

        private void SwitchSound()
        {
            if (_soundON)
            {
              SetSoundState(false);
            }
            else
            {
                SetSoundState(true);
            }
            ChangeSound?.Invoke(_soundON);
        }

        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
            
        }

        public void SetSoundState(bool soundState)
        {
            _soundON = soundState;
            soundOffImage.gameObject.SetActive(!soundState);
            
        }

        public void SetLevelState(int levelNumber, int maxLevel)
        {
            _levelNumber = levelNumber+1;
            _maxLevel = maxLevel;
            levelText.text = _levelNumber.ToString();
        }
    }
}