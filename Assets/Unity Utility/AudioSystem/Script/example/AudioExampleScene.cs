using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MyUtility
{
    public class AudioExampleScene : MonoBehaviour
    {

        [SerializeField] private Image _soundSettingButton;
        [SerializeField] private Sprite _spriteSoundOn;
        [SerializeField] private Sprite _spriteSoundOff;


        private void Awake()
        {
            AudioManager.onAudioStateChange += onSOundStateChange;
        }

        private void OnDestroy()
        {
            AudioManager.onAudioStateChange -= onSOundStateChange;
        }

        private void Start()
        {
            SetSoundButtonGraphics();
        }
        public void OnSoundButtonClicked()
        {
            AudioManager.instance.ChangeGameAudioStatus();
            SetSoundButtonGraphics();
        }



        void onSOundStateChange(bool isSoundOn)
        {
            SetSoundButtonGraphics();
        }
        private void SetSoundButtonGraphics()
        {
            bool isAudioOn = AudioManager.instance.IsGameAudioOn();
            if (isAudioOn)
                _soundSettingButton.sprite = _spriteSoundOn;
            else
                _soundSettingButton.sprite = _spriteSoundOff;
        }


    }
}

  
