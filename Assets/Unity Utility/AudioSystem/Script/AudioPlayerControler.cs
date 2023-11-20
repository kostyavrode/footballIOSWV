using UnityEngine;

namespace MyUtility
{
    [RequireComponent(typeof(AudioSource))]
    public class AudioPlayerControler : MonoBehaviour, IAudio
    {
        [Header("Set Audio Clip (Optional)")]
        [SerializeField] private AudioClip _clip;
        [SerializeField] private bool _isBackgroundSound = false;

        private AudioSource _audioSource;
        private AudioManager.AudioState _currentAudioState = AudioManager.AudioState.Idle;


        private void Awake()
        {
            AudioManager.onAudioStateChange += AudioStateChanged;
        }
        private void OnDestroy()
        {
            AudioManager.onAudioStateChange -= AudioStateChanged;
        }


        public void PlaySound()
        {
            PlaySound(_clip, GetAudioSource());
        }

        public void PlaySound(AudioClip clip)
        {
            PlaySound(clip, GetAudioSource());
        }

        public void PlaySound(AudioClip clip, AudioSource source)
        {
            if (source != null && clip != null)
            {
                this._clip = clip;
                this._audioSource = source;

                source.clip = clip;


                if (AudioManager.instance.IsGameAudioOn() == true)
                {
                    _currentAudioState = AudioManager.AudioState.Playing;
                    source.Play();
                }
                else if (_isBackgroundSound == true)
                    _currentAudioState = AudioManager.AudioState.Pause;

            }
        }

        public void PauseSound()
        {
            if (GetAudioSource() != null && _clip != null)
            {
                if (GetAudioSource().isPlaying == true)
                {
                    GetAudioSource().Pause();
                    _currentAudioState = AudioManager.AudioState.Pause;
                }

            }
        }

        public void ResumeSound()
        {
            PlaySound();
        }

        public void StopSound()
        {
            if (GetAudioSource() != null && _clip != null)
            {
                if (GetAudioSource().isPlaying == true)
                {
                    GetAudioSource().Stop();
                    _currentAudioState = AudioManager.AudioState.Stop;
                }
            }
        }

        public AudioManager.AudioState GetCurrentAudioState()
        {
            return _currentAudioState;
        }

        private AudioSource GetAudioSource()
        {
            if (_audioSource == null)
                _audioSource = this.gameObject.GetComponent<AudioSource>();
            return _audioSource;
        }

        private void AudioStateChanged(bool isSoundOn)
        {
            if (isSoundOn)
            {
                if (_currentAudioState == AudioManager.AudioState.Pause && _isBackgroundSound == true)
                    ResumeSound();
            }
            else
            {
                PauseSound();
            }
        }

    }
}


