using System;
using UnityEngine;

namespace GamePlay
{
    [RequireComponent(typeof(AudioSource))]
    public class PlayerSounds : MonoBehaviour, IUpSound
    {
        [SerializeField] private AudioClip upSound;
        [SerializeField] private AudioClip lostSound;
        [SerializeField] private AudioClip addCoinSound;
        private AudioSource _audioSource;

        private void Start()
        {
            _audioSource = GetComponent<AudioSource>();
        }

        public void PlayUpSound()
        {
            ChangeAudio(upSound);
        }

        public void PlayLostSound()
        {
            ChangeAudio(lostSound);
        }

        public void PlayAddCoin()
        {
            ChangeAudio(addCoinSound);
        }

        private void ChangeAudio(AudioClip clip)
        {
            _audioSource.clip = clip;
            _audioSource.Play();
        }
    }
}