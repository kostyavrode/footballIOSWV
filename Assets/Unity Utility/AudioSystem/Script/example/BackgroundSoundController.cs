using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyUtility
{

    public class BackgroundSoundController : MonoBehaviour
    {
        [SerializeField] private AudioClip _clip;
        [SerializeField] private AudioPlayerControler _audioController;

        private void Start()
        {
            _audioController.PlaySound(_clip);
        }
    }

}
