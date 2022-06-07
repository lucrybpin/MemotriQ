using LevelManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace LevelManagement
{
    public class WinMenu :Menu<WinMenu>
    {
        [SerializeField]
        TextMeshProUGUI _scoreText;

        public void SetScore(int score) {
            _scoreText.text = score.ToString();
        }

        public void OnRestartPressed() {
            AudioManager.Instance.PlayButtonClick();
            base.OnBackPressed();
            SceneUtilities.ReloadLevel();
        }

        public void OnMainMenuPressed() {
            AudioManager.Instance.PlayButtonClick();
            base.OnBackPressed();
            SceneUtilities.LoadMainMenuLevel();
        }
    } 
}
