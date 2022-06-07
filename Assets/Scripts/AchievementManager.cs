using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LevelManagement.Data;

namespace LevelManagement
{
    public class AchievementManager :MonoBehaviour
    {
        private static AchievementManager _instance;

        public static AchievementManager Instance { get { return _instance; } }

        private DataManager _dataManager;

        private void Awake () {
            _dataManager = Object.FindObjectOfType<DataManager>();
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

        private void Start () {
        }

        public void SetLevelAchievement (int gridSize) {
            if (gridSize == 4) {
                if (_dataManager.Achievement2x2 == false) {
                    _dataManager.Achievement2x2 = true;
                }
            } else if (gridSize == 9) {
                if (_dataManager.Achievement3x3 == false) {
                    _dataManager.Achievement3x3 = true;
                }
            } else if (gridSize == 16) {
                Debug.Log("SetLevelAchievement 4x4");
                if (_dataManager.Achievement4x4 == false) {
                    _dataManager.Achievement4x4 = true;
                }
            } else if (gridSize == 25) {
                if (_dataManager.Achievement5x5 == false) {
                    _dataManager.Achievement5x5 = true;
                }
            }
            Debug.Log("Salvando");
            _dataManager.Save();
        }

    }
}
