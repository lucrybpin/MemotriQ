using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using LevelManagement.Data;

namespace LevelManagement {
    public class MainMenu :Menu<MainMenu>
    {
        [SerializeField]
        private float _playDelay = 0.5f;

        [SerializeField]
        private TransitionFader startTransitionPrefab;

        [SerializeField]
        private InputField _inputField;

        [SerializeField]
        private MainMenuHeaderEffect _mainMenuHeaderEffect;

        protected override void Awake () {
            base.Awake();
        }

        private void Start () {
            LoadData();
            Debug.Log("Applicaiton Version:" + Application.version);
        }

        public override void BeforeLoad() {
            _mainMenuHeaderEffect.StartEffect();
        }

        private void LoadData() {
            DataManager.Instance.Load();
        }

        public void OnPlayPressed() {
            PlayMenu.Open();
            AudioManager.Instance.PlayButtonClick();
        }

        public void OnShopPressed() {
            ShopMenu.Open();
            AudioManager.Instance.PlayButtonClick();
        }

        public void OnSettingsPressed () {
            SettingsMenu.Open();
            AudioManager.Instance.PlayButtonClick();
        }

        public void OnCreditsPressed () {
            CreditsMenu.Open();
            AudioManager.Instance.PlayButtonClick();
        }

        public override void OnBackPressed () {
            AudioManager.Instance.PlayButtonClick();
            Application.Quit();
        }

    }
}