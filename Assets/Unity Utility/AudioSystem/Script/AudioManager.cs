using SaveSystem;
using UnityEngine;

namespace MyUtility
{
    public class AudioManager : MonoBehaviour
    {
        public static AudioManager instance;

        public delegate void GameAudioStateChange(bool isAudioOn);
        public static event GameAudioStateChange onAudioStateChange;

        public enum AudioState { Playing, Pause, Stop, Idle };

        private string soundSettingJsonFileName = "GameSoundSettingData.json";


        private void Awake()
        {
            if (instance == null)
                instance = this;
        }


        public bool IsGameAudioOn()
        {
            return GetSavedSoundSettingData().isGameAudioOn;
        }

        public void ChangeGameAudioStatus()
        {
            GameAudioSavedData data = GetSavedSoundSettingData();
            data.isGameAudioOn = !data.isGameAudioOn;

            SaveDataHandler.SaveData(data, GetFilePath());

            if (onAudioStateChange != null)
                onAudioStateChange(data.isGameAudioOn);
        }

        private string GetFilePath()
        {
            return FileHandler.GetPersistantFilePath(soundSettingJsonFileName);
        }

        private GameAudioSavedData GetSavedSoundSettingData()
        {
            return SaveDataHandler.GetData<GameAudioSavedData>(GetFilePath(), new GameAudioSavedData());
        }
    }

}

