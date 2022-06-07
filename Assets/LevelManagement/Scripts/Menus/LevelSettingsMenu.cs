using LevelManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace LevelManagement
{
    public class LevelSettingsMenu :Menu<LevelSettingsMenu> {
        [SerializeField]
        private Color unpressedColor;
        [SerializeField]
        private Color pressedColor;

        [SerializeField]
        private Button _orderDecreasingButton;
        [SerializeField]
        bool _decreasing = false;
        public bool Decreasing {
            get { return _decreasing; }
            set {
                if (value == false) {
                    ColorBlock buttonColors = _orderDecreasingButton.colors;
                    buttonColors.normalColor = unpressedColor;
                    buttonColors.highlightedColor = unpressedColor;
                    _orderDecreasingButton.colors = buttonColors;
                } else {
                    ColorBlock buttonColors = _orderDecreasingButton.colors;
                    buttonColors.normalColor = pressedColor;
                    buttonColors.highlightedColor = pressedColor;
                    _orderDecreasingButton.colors = buttonColors;
                }
                _decreasing = value;
            }
        }

        [SerializeField]
        private Button _perfectionistButton;
        [SerializeField]
        bool _perfectionist = false;
        public bool Perfectionist {
            get { return _perfectionist; }
            set {
                if (value == false) {
                    ColorBlock buttonColors = _perfectionistButton.colors;
                    buttonColors.normalColor = unpressedColor;
                    buttonColors.highlightedColor = unpressedColor;
                    _perfectionistButton.colors = buttonColors;
                } else {
                    ColorBlock buttonColors = _perfectionistButton.colors;
                    buttonColors.normalColor = pressedColor;
                    buttonColors.highlightedColor = pressedColor;
                    _perfectionistButton.colors = buttonColors;
                }
                _perfectionist = value;
            }
        }

        [SerializeField]
        private Button _highValuesButton;
        [SerializeField]
        bool _highValues = false;
        public bool HighValues {
            get { return _highValues; }
            set {
                if (value == false) {
                    ColorBlock buttonColors = _highValuesButton.colors;
                    buttonColors.normalColor = unpressedColor;
                    buttonColors.highlightedColor = unpressedColor;
                    _highValuesButton.colors = buttonColors;
                } else {
                    ColorBlock buttonColors = _highValuesButton.colors;
                    buttonColors.normalColor = pressedColor;
                    buttonColors.highlightedColor = pressedColor;
                    _highValuesButton.colors = buttonColors;
                }
                _highValues = value;
            }
        }

        [SerializeField]
        private Button _letMeClickButton;
        [SerializeField]
        bool _letMeClick = false;
        public bool LetMeClick {
            get { return _letMeClick; }
            set {
                if (value == false) {
                    ColorBlock buttonColors = _letMeClickButton.colors;
                    buttonColors.normalColor = unpressedColor;
                    buttonColors.highlightedColor = unpressedColor;
                    _letMeClickButton.colors = buttonColors;
                } else {
                    ColorBlock buttonColors = _letMeClickButton.colors;
                    buttonColors.normalColor = pressedColor;
                    buttonColors.highlightedColor = pressedColor;
                    _letMeClickButton.colors = buttonColors;
                }
                _letMeClick = value;
            }
        }

        [SerializeField]
        private Button _alwaysReadyButton;
        [SerializeField]
        bool _alwaysReady = false;
        public bool AlwaysReady {
            get { return _alwaysReady; }
            set {
                if (value == false) {
                    ColorBlock buttonColors = _alwaysReadyButton.colors;
                    buttonColors.normalColor = unpressedColor;
                    buttonColors.highlightedColor = unpressedColor;
                    _alwaysReadyButton.colors = buttonColors;
                } else {
                    ColorBlock buttonColors = _alwaysReadyButton.colors;
                    buttonColors.normalColor = pressedColor;
                    buttonColors.highlightedColor = pressedColor;
                    _alwaysReadyButton.colors = buttonColors;
                }
                _alwaysReady = value;
            }
        }

        [SerializeField]
        private Button _rushModeButton;
        [SerializeField]
        bool _rushMode = false;
        public bool RushMode {
            get { return _rushMode; }
            set {
                if (value == false) {
                    ColorBlock buttonColors = _rushModeButton.colors;
                    buttonColors.normalColor = unpressedColor;
                    buttonColors.highlightedColor = unpressedColor;
                    _rushModeButton.colors = buttonColors;
                } else {
                    ColorBlock buttonColors = _rushModeButton.colors;
                    buttonColors.normalColor = pressedColor;
                    buttonColors.highlightedColor = pressedColor;
                    _rushModeButton.colors = buttonColors;
                }
                _rushMode = value;
            }
        }

        [SerializeField]
        private Button _simpleShuffleButton;
        [SerializeField]
        bool _simpleShuffle = false;
        public bool SimpleShuffle {
            get { return _simpleShuffle; }
            set {
                if (value == false) {
                    ColorBlock buttonColors = _simpleShuffleButton.colors;
                    buttonColors.normalColor = unpressedColor;
                    buttonColors.highlightedColor = unpressedColor;
                    _simpleShuffleButton.colors = buttonColors;
                } else {
                    ColorBlock buttonColors = _simpleShuffleButton.colors;
                    buttonColors.normalColor = pressedColor;
                    buttonColors.highlightedColor = pressedColor;
                    _simpleShuffleButton.colors = buttonColors;
                }
                _simpleShuffle = value;
            }
        }

        [SerializeField]
        private Button _threeShuffleButton;
        [SerializeField]
        bool _threeShuffle = false;
        public bool ThreeShuffle {
            get { return _threeShuffle; }
            set {
                if (value == false) {
                    ColorBlock buttonColors = _threeShuffleButton.colors;
                    buttonColors.normalColor = unpressedColor;
                    buttonColors.highlightedColor = unpressedColor;
                    _threeShuffleButton.colors = buttonColors;
                } else {
                    ColorBlock buttonColors = _threeShuffleButton.colors;
                    buttonColors.normalColor = pressedColor;
                    buttonColors.highlightedColor = pressedColor;
                    _threeShuffleButton.colors = buttonColors;
                }
                _threeShuffle = value;
            }
        }

        [SerializeField]
        private Button _randomSortButton;
        [SerializeField]
        bool _randomSort = false;
        public bool RandomSort {
            get { return _randomSort; }
            set {
                if (value == false) {
                    ColorBlock buttonColors = _randomSortButton.colors;
                    buttonColors.normalColor = unpressedColor;
                    buttonColors.highlightedColor = unpressedColor;
                    _randomSortButton.colors = buttonColors;
                } else {
                    ColorBlock buttonColors = _randomSortButton.colors;
                    buttonColors.normalColor = pressedColor;
                    buttonColors.highlightedColor = pressedColor;
                    _randomSortButton.colors = buttonColors;
                }
                _randomSort = value;
            }
        }


        [ SerializeField]
        private TransitionFader startTransitionPrefab;

        [SerializeField]
        private float _playDelay = 1.2f;

        protected override void Awake () {
            base.Awake();
        }

        public override void BeforeLoad () {
            //_mainMenuHeaderEffect.StartEffect();
            //SetupButtons();
        }

        public void OnOrderDecreasingButtonPressed() {
            AudioManager.Instance.PlayButtonClick2();
            Decreasing = !Decreasing;
            Data.DataManager.Instance.Difficulty.Decrescent = Decreasing;
            if (RandomSort == true) {
                RandomSort = !RandomSort;
                Data.DataManager.Instance.Difficulty.RandomSort = RandomSort;
            }
        }

        public void OnPerfectionistButtonPressed() {
            AudioManager.Instance.PlayButtonClick2();
            Perfectionist = !Perfectionist;
            Data.DataManager.Instance.Difficulty.Perfectionist = Perfectionist;
            //Disable Let Me Click
            if (LetMeClick == true) {
                LetMeClick = !LetMeClick;
                Data.DataManager.Instance.Difficulty.LetMeClick = LetMeClick;
            }
        }

        public void OnRandomSort() {
            AudioManager.Instance.PlayButtonClick2();
            RandomSort = !RandomSort;
            Data.DataManager.Instance.Difficulty.RandomSort = RandomSort;
            if (Decreasing == true) {
                Decreasing = !Decreasing;
                Data.DataManager.Instance.Difficulty.Decrescent = Decreasing;
            }
        }

        public void OnHighValuesButtonPressed() {
            AudioManager.Instance.PlayButtonClick2();
            HighValues = !HighValues;
            Data.DataManager.Instance.Difficulty.HighValues = HighValues;
        }

        public void OnAlwaysReadyButtonPressed() {
            AudioManager.Instance.PlayButtonClick2();
            AlwaysReady = !AlwaysReady;
            Data.DataManager.Instance.Difficulty.AlwaysReady = AlwaysReady;
        }

        public void OnLetMeClickButtonPressed() {
            AudioManager.Instance.PlayButtonClick2();
            LetMeClick = !LetMeClick;
            Data.DataManager.Instance.Difficulty.LetMeClick = LetMeClick;
            //Disable Perfectionist
            if (Perfectionist == true) {
                Perfectionist = !Perfectionist;
                Data.DataManager.Instance.Difficulty.Perfectionist = Perfectionist;
            }
        }

        public void OnSimpleShuffleButtonPressed() {
            AudioManager.Instance.PlayButtonClick2();
            SimpleShuffle = !SimpleShuffle;
            Data.DataManager.Instance.Difficulty.SimpleShuffle = SimpleShuffle;
            //Disable Three Shuffle
            if (ThreeShuffle == true) {
                ThreeShuffle = !ThreeShuffle;
                Data.DataManager.Instance.Difficulty.ThreeShuffle = ThreeShuffle;
            }
        }

        public void OnThreeShuffleButtonPressed() {
            AudioManager.Instance.PlayButtonClick2();
            ThreeShuffle = !ThreeShuffle;
            Data.DataManager.Instance.Difficulty.ThreeShuffle = ThreeShuffle;
            //Disable Simple Shuffle
            if (SimpleShuffle == true) {
                SimpleShuffle = !SimpleShuffle;
                Data.DataManager.Instance.Difficulty.SimpleShuffle = SimpleShuffle;
            }
        }

        public void OnRushModeButtonPressed() {
            AudioManager.Instance.PlayButtonClick2();
            RushMode = !RushMode;
            Data.DataManager.Instance.Difficulty.RushMode = RushMode;
        }

        public void OnPlayPressed() {
            AudioManager.Instance.PlayButtonClick();
            StartCoroutine(OnPlayPressedRoutine(GameManager.Instance.LevelSelected));
        }

        public override void OnBackPressed () {
            AudioManager.Instance.PlayButtonClick();
            base.OnBackPressed();
        }

        private IEnumerator OnPlayPressedRoutine (string levelToLoad) {
            TransitionFader.PlayTransition(startTransitionPrefab);
            yield return new WaitForSeconds(0.4f);
            if (GameManager.Instance != null) {
                SceneUtilities.LoadLevel(levelToLoad);
            }
            yield return new WaitForSeconds(_playDelay);
            GameMenu.Open();
        }
    } 
}
