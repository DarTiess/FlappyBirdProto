using System;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace UI.UIPanels
{
    public class SettingsPanel : MonoBehaviour
    {
        [SerializeField] private Button _continueButton;
        [Header("Sound Settings")]
        [SerializeField] private Button _soundButton;
        [SerializeField] private Image _soundOffImage;
        [Header("Levels Settings")]
        [SerializeField] private Button _minusLevelButton;
        [SerializeField] private Button _plusLevelButton;
        [SerializeField] private Text _levelText;

        public event Action<bool> ChangeSound;
        public event Action<int> ChangeLevel;
        private bool _soundON=true;
        private int _levelNumber;
        private int _maxLevel;

        private void Start()
        {
            _continueButton.onClick.AddListener(Hide);
            _soundButton.onClick.AddListener(SwitchSound);
            _minusLevelButton.onClick.AddListener(MinusLevel);
            _plusLevelButton.onClick.AddListener(PlusLevel);
            SwitchSound();
        }

        private void PlusLevel()
        {
            if (_levelNumber <= _maxLevel)
            {
                _levelNumber += 1;
                _levelText.text = _levelNumber.ToString();
                ChangeLevel?.Invoke(_levelNumber-1);
            }
        }

        private void MinusLevel()
        {
            if (_levelNumber > 0)
            {
                _levelNumber -= 1;
                _levelText.text = _levelNumber.ToString();
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
            _soundOffImage.gameObject.SetActive(!soundState);
            
        }

        public void SetLevelState(int levelNumber, int maxLevel)
        {
            _levelNumber = levelNumber+1;
            _maxLevel = maxLevel;
            _levelText.text = _levelNumber.ToString();
        }
    }
}