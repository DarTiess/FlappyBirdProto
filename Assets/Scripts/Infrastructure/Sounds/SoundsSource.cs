using Infrastructure.Coins;
using Infrastructure.Level;
using UI;
using UI.Touch;
using UnityEngine;

namespace Infrastructure.Sounds
{
    [RequireComponent(typeof(AudioSource))]
    public class SoundsSource : MonoBehaviour
    {
        [SerializeField] private AudioClip upSound;
        [SerializeField] private AudioClip lostSound;
        [SerializeField] private AudioClip addCoinSound;
        private AudioSource _audioSource;
        private ILevelEvents _levelEvents;
        private ICoinsEvents _coins;
        private ITouchPad _touch;
        private ISoundUIEvent _soundUI;
        private ISoundDataChange _soundData;
       
        public void Init(ILevelEvents levelEvents, 
                         ICoinsEvents coins, 
                         ITouchPad touch, 
                         ISoundUIEvent soundUI, 
                         bool soundState, 
                         ISoundDataChange soundData)
        {
            _audioSource = GetComponent<AudioSource>();
            _levelEvents = levelEvents;
            _coins = coins;
            _touch = touch;
            _soundUI = soundUI;
            _soundData = soundData;
            
            _levelEvents.LevelLost += PlayLostSound;
            _coins.ChangeCoins += PlayAddCoin;
            _touch.ClickedTouch += PlayUpSound;
            _soundUI.ChangeSoundState += OnChangeSoundUIState;
            
            OnChangeSoundUIState(soundState);
        }

        private void OnDestroy()
        {
            _levelEvents.LevelLost -= PlayLostSound;
            _coins.ChangeCoins -= PlayAddCoin;
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
            ChangeAudio(upSound);
        }

        private void PlayLostSound()
        {
            ChangeAudio(lostSound);
        }

        private void PlayAddCoin(int coins)
        {
            ChangeAudio(addCoinSound);
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