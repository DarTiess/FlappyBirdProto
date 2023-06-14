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
        private bool _soundON=true;
        private int _levelNumber;

        private void Start()
        {
            continueButton.onClick.AddListener(Hide);
            soundButton.onClick.AddListener(SwitchSound);
            minusLevelButton.onClick.AddListener(MinusLevel);
            plusLevelButton.onClick.AddListener(PlusLevel);
           // soundOffImage.gameObject.SetActive(false);
        }

        private void PlusLevel()
        {
            _levelNumber += 1;
            levelText.text = _levelNumber.ToString();
        }

        private void MinusLevel()
        {
            _levelNumber -= 1;
            levelText.text = _levelNumber.ToString();
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
    }
}