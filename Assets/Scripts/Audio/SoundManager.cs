using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyUtility;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioClip kickSoundClip;
    [SerializeField] private AudioClip targetCollideSoundClip;


    [SerializeField] private AudioPlayerControler _kickSound;
    [SerializeField] private AudioPlayerControler _bgSound;
    [SerializeField] private AudioPlayerControler _celebrationSound;


    [SerializeField] private Image _soundSettingButton;
    [SerializeField] private Sprite _spriteSoundOn;
    [SerializeField] private Sprite _spriteSoundOff;

    private void Start()
    {
        SetSoundButtonGraphics();
        PlayBackgroundSound();
    }

    public void PlayKickSound()
    {
        _kickSound.PlaySound(kickSoundClip);
    }

    public void PlayCelebrationSound()
    {
        _celebrationSound.PlaySound();
    }


    public void PlayTargetCollideSound()
    {
        _kickSound.PlaySound(targetCollideSoundClip);
    }

    public void PlayBackgroundSound()
    {
        _bgSound.PlaySound();
    }

    public void StopBackgroundSound()
    {
        _bgSound.PlaySound();
    }

    private void Awake()
    {
        AudioManager.onAudioStateChange += onSOundStateChange;
    }

    private void OnDestroy()
    {
        AudioManager.onAudioStateChange -= onSOundStateChange;
    }

   
    public void OnSoundButtonClicked()
    {
        AudioManager.instance.ChangeGameAudioStatus();
        SetSoundButtonGraphics();
        PlayBackgroundSound();
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
