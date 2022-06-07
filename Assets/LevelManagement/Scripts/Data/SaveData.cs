using System.Collections;
using System.Collections.Generic;
using System;

namespace LevelManagement.Data
{
    [Serializable]
    public class SaveData
    {
        public string playerName;
        private readonly string defaultPlayerName = "Player";

        public bool achievement2x2;
        public bool achievement3x3;
        public bool achievement4x4;
        public bool achievement5x5;

        public float masterVolume;
        public float sfxVolume;
        public float musicVolume;
        public int voiceIndex;
        public int points;
        public int cubes;

        public string hashValue;

        public SaveData() {
            playerName = defaultPlayerName;
            achievement2x2 = false;
            achievement3x3 = false;
            achievement4x4 = false;
            achievement5x5 = false;
            points = 0;
            cubes = 0;
            masterVolume = 0f;
            sfxVolume = 0f;
            musicVolume = 0f;
            voiceIndex = 0;
            hashValue = String.Empty;
        }

    } 
}
