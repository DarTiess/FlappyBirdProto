using Infrastructure.Coins;
using Infrastructure.Level;
using UI;
using UI.Touch;
using UnityEngine;
using UnityEngine.Serialization;

namespace Infrastructure.Sounds
{
    [RequireComponent(typeof(AudioSource))]
    public class SoundsSource : MonoBehaviour
    {
        [SerializeField] private AudioClip _upSound;
        [SerializeField] private AudioClip _lostSound;
        [SerializeField] private AudioClip _addCoinSound;
      
        private AudioSource _audioSource;
        private ILevelEvents _levelEvents;
        private IChangeEconomicEvents _changeEconomic;
        private ITouchPad _touch;
        private ISoundUIEvent _soundUI;
        private ISoundDataChange _soundData;
       
        public void Init(ILevelEvents levelEvents, 
                         IChangeEconomicEvents changeEconomic, 
                         ITouchPad touch, 
                         ISoundUIEvent soundUI, 
                         bool soundState, 
                         ISoundDataChange soundData)
        {
            _audioSource = GetComponent<AudioSource>();
            _levelEvents = levelEvents;
            _changeEconomic = changeEconomic;
            _touch = touch;
            _soundUI = soundUI;
            _soundData = soundData;
            
            _levelEvents.LevelLost += PlayLostSound;
            _changeEconomic.ChangeData += PlayAddChangeEconomic;
            _touch.ClickedTouch += PlayUpSound;
            _soundUI.ChangeSoundState += OnChangeSoundUIState;
            
            OnChangeSoundUIState(soundState);
        }

        private void OnDestroy()
        {
            _levelEvents.LevelLost -= PlayLostSound;
            _changeEconomic.ChangeData -= PlayAddChangeEconomic;
            _touch.ClickedTouch -= PlayUpSound;
            _soundUI.ChangeSoundState -= OnChangeSoundUIState;
        }

        private void OnChangeSoundUIState(bool state)
        {
            _audioSource.gameObject.SetActive(state);
            _soundData.ChangeSoundState(state);
        }

        private void PlayUpSound()
        {
            ChangeAudio(_upSound);
        }

        private void PlayLostSound()
        {
            ChangeAudio(_lostSound);
        }

        private void PlayAddChangeEconomic(int coins)
        {
            ChangeAudio(_addCoinSound);
        }

        private void ChangeAudio(AudioClip clip)
        {
            if (_audioSource.isActiveAndEnabled)
            {
                _audioSource.clip = clip;
                _audioSource.Play();
            }
           
        }
    }
}