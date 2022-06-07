using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LevelManagement.Data
{
    public class DataManager :MonoBehaviour
    {
        private SaveData _saveData;
        private JsonSaver _jsonSaver;

        private static DataManager _instance;

        public static DataManager Instance { get { return _instance; } }

        [SerializeField]
        Difficulty _difficulty = new Difficulty();
        public Difficulty Difficulty {
            get {
                return _difficulty;
            }
        }

        private void Awake () {
            _saveData = new SaveData();
            _jsonSaver = new JsonSaver();
            if (_instance != null) {
                Destroy(gameObject);
            } else {
                _instance = this;
            }
        }

        private void OnDestroy () {
            if (_instance == this) {
                _instance = null;
            }
        }

        public float MasterVolume {
            get { return _saveData.masterVolume; }
            set { _saveData.masterVolume = value; }
        }

        public float SfxVolume {
            get { return _saveData.sfxVolume; }
            set { _saveData.sfxVolume = value; }
        }

        public float MusicVolume {
            get { return _saveData.musicVolume; }
            set { _saveData.musicVolume = value; }
        }

        public int VoiceIndex {
            get { return _saveData.voiceIndex; }
            set { _saveData.voiceIndex = value; }
        }

        public string PlayerName {
            get { return _saveData.playerName; }
            set { _saveData.playerName = value; }
        }

        public bool Achievement2x2 {
            get { return _saveData.achievement2x2; }
            set { _saveData.achievement2x2 = value; }
        }

        public bool Achievement3x3 {
            get { return _saveData.achievement3x3; }
            set { _saveData.achievement3x3 = value; }
        }

        public bool Achievement4x4 {
            get { return _saveData.achievement4x4; }
            set { _saveData.achievement4x4 = value; }
        }

        public bool Achievement5x5 {
            get { return _saveData.achievement5x5; }
            set { _saveData.achievement5x5 = value; }
        }

        public void AddPoints(int points) {
            if (points >= 0) {
                _saveData.points += points;
            }  
        }

        public int GetPoints() {
            return _saveData.points;
        }

        public void Save() {
            _jsonSaver.Save(_saveData);
        }

        public void Load() {
            Debug.Log("Loading data");
            _jsonSaver.Load(_saveData);
        }
    } 
}
