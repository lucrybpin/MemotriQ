using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using LevelManagement.Data;

namespace LevelManagement {
    public class PlayMenu :Menu<PlayMenu>
    {
        [SerializeField]
        private float _playDelay = 0.5f;

        [SerializeField]
        private TransitionFader startTransitionPrefab;

        [SerializeField]
        private InputField _inputField;

        [SerializeField]
        private Button _button3x3;

        [SerializeField]
        private Button _button4x4;

        [SerializeField]
        private Button _button5x5;

        [SerializeField]
        private MainMenuHeaderEffect _mainMenuHeaderEffect;

        protected override void Awake () {
            base.Awake();
        }

        private void Start () {
            LoadData();
            SetupButtons();
        }

        public override void BeforeLoad() {
            _mainMenuHeaderEffect.StartEffect();
            SetupButtons();
        }

        private void LoadData() {
            DataManager.Instance.Load();
        }

        public void OnPlayPressed() {
            
        }

        public void On2x2Pressed () {
            //StartCoroutine(OnPlayPressedRoutine("Level2x2"));
            AudioManager.Instance.PlayButtonClick();
            GameManager.Instance.LevelSelected = "Level2x2";
            LevelSettingsMenu.Open();
        }

        public void On3x3Pressed() {
            //StartCoroutine(OnPlayPressedRoutine("Level3x3"));
            AudioManager.Instance.PlayButtonClick();
            GameManager.Instance.LevelSelected = "Level3x3";
            LevelSettingsMenu.Open();
        }

        public void On4x4Pressed () {
            //StartCoroutine(OnPlayPressedRoutine("Level4x4"));
            AudioManager.Instance.PlayButtonClick();
            GameManager.Instance.LevelSelected = "Level4x4";
            LevelSettingsMenu.Open();
        }
        public void On5x5Pressed () {
            //StartCoroutine(OnPlayPressedRoutine("Level5x5"));
            AudioManager.Instance.PlayButtonClick();
            GameManager.Instance.LevelSelected = "Level5x5";
            LevelSettingsMenu.Open();
        }

        private IEnumerator OnPlayPressedRoutine(string levelToLoad) {
            TransitionFader.PlayTransition(startTransitionPrefab);
            if (GameManager.Instance != null) {
                //SceneUtilities.LoadNextLevel();
                SceneUtilities.LoadLevel(levelToLoad);
            }
            yield return new WaitForSeconds(_playDelay);
            GameMenu.Open();
        }

        public override void OnBackPressed () {
            AudioManager.Instance.PlayButtonClick();
            base.OnBackPressed();
        }

        private void SetupButtons() {
            if (DataManager.Instance.Achievement2x2 == true) {
                _button3x3.interactable = true;
            } else {
                _button3x3.interactable = false;
            }

            if (DataManager.Instance.Achievement3x3 == true) {
                _button4x4.interactable = true;
            } else {
                _button4x4.interactable = false;
            }

            if (DataManager.Instance.Achievement4x4 == true) {
                _button5x5.interactable = true;
            } else {
                _button5x5.interactable = false;
            }
        }
    }
}