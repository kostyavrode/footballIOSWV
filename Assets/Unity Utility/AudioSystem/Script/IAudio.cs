using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyUtility
{
    public interface IAudio
    {
        void PlaySound();
        void PlaySound(AudioClip clip);
        void PlaySound(AudioClip clip, AudioSource source);
        void PauseSound();
        void ResumeSound();
        void StopSound();
    }
}


