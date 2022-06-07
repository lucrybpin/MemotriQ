using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace LevelManagement {
    public class LevelManager :MonoBehaviour
    {
        [SerializeField]
        int gridSize;

        [SerializeField]
        List<GameCell> cells;

        [SerializeField]
        List<int> valuesList = new List<int>();

        int _currentIndex;
        int _numOfClicks;
        float timer;

        [SerializeField]
        bool _isSolving;

        private IEnumerator _timerCoroutine;

        private static LevelManager _instance;


        [SerializeField]
        private int _score;

        public int Score { get { return _score; } }

        public static LevelManager Instance { get { return _instance; } }

        public int GridSize { get { return gridSize; } }

        public float Timer { get { return timer; } }

        [SerializeField]
        private float _rushModeTimer = 0;

        private void Awake () {
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

        void Start () {
            PrepareGrid();
            UIManager.Instance.UpdateTextNumOfClicks(0);
            _score = 0;
            _timerCoroutine = UpdateTimer();
            _isSolving = false;
        }

        public void Ready () {
            DisableCells();
            foreach (GameCell cell in cells) {
                cell.ShowButton();
                cell.DisableButton();
            }
            UIManager.Instance.DisableButtonReady();
            UIManager.Instance.EnableButtonGo();
            AudioManager.Instance.PlayReady();

            if (Data.DataManager.Instance.Difficulty.AlwaysReady == true) {
                StartCoroutine(_timerCoroutine);
            }
        }

        public void StartSolution () {

            if (Data.DataManager.Instance.Difficulty.RandomSort == true) {
                UIManager.Instance.SetOrderTextCrescent();
                if (UnityEngine.Random.Range(0f, 1f) > 0.5f) {
                    cells.Reverse();
                    UIManager.Instance.SetOrderTextDecrescent();
                }
                UIManager.Instance.EnableOrderText();
            }

            //Hide Cells
            foreach (GameCell cell in cells) {
                cell.HideButton();
                cell.EnableButton();
            }
            _isSolving = true;

            //Disable Buttons
            UIManager.Instance.DisableButtonGo();

            //Start Timer in Always Ready mode
            if (Data.DataManager.Instance.Difficulty.AlwaysReady == false) {
                StartCoroutine(_timerCoroutine);
            }

            if (Data.DataManager.Instance.Difficulty.SimpleShuffle == true || 
                Data.DataManager.Instance.Difficulty.ThreeShuffle == true) {

                StartCoroutine(ShuffleStartCoroutine());

            } else {

                EnableCells();
                AudioManager.Instance.PlayGo();

                if (Data.DataManager.Instance.Difficulty.RushMode == true) {
                    StartCoroutine(RushModeTimerControl());
                }
            }
            
        }


        private IEnumerator ShuffleStartCoroutine() {
            
            if (Data.DataManager.Instance.Difficulty.SimpleShuffle == true) {
                int indexButton1 = UnityEngine.Random.Range(0, cells.Count);
                int indexButton2;
                do {
                    indexButton2 = UnityEngine.Random.Range(0, cells.Count);
                }
                while (indexButton2 == indexButton1);
                SwapButtons(cells [ indexButton1 ].gameObject, cells [ indexButton2 ].gameObject);
                yield return new WaitForSeconds(2.5f);
            } else if (Data.DataManager.Instance.Difficulty.ThreeShuffle == true) {
                int indexButton1 = UnityEngine.Random.Range(0, cells.Count);
                int indexButton2;
                do {
                    indexButton2 = UnityEngine.Random.Range(0, cells.Count);
                }
                while (indexButton2 == indexButton1);
                SwapButtons(cells [ indexButton1 ].gameObject, cells [ indexButton2 ].gameObject);
                yield return new WaitForSeconds(2.5f);

                indexButton1 = UnityEngine.Random.Range(0, cells.Count);
                do {
                    indexButton2 = UnityEngine.Random.Range(0, cells.Count);
                }
                while (indexButton2 == indexButton1);
                SwapButtons(cells [ indexButton1 ].gameObject, cells [ indexButton2 ].gameObject);
                yield return new WaitForSeconds(2.5f);

                indexButton1 = UnityEngine.Random.Range(0, cells.Count);
                do {
                    indexButton2 = UnityEngine.Random.Range(0, cells.Count);
                }
                while (indexButton2 == indexButton1);
                SwapButtons(cells [ indexButton1 ].gameObject, cells [ indexButton2 ].gameObject);
                yield return new WaitForSeconds(2.5f);
            }
            
            EnableCells();

            AudioManager.Instance.PlayGo();

            if (Data.DataManager.Instance.Difficulty.RushMode == true) {
                StartCoroutine(RushModeTimerControl());
            }
            yield return null;
        }

        private void SwapButtons(GameObject button1, GameObject button2) {
            //Shuffle then go
            iTween.ScaleTo(button1, iTween.Hash("scale", new Vector3(0.7f, 0.7f, 0.7f), "time", 0.7f, "delay", 0f, "easetype", iTween.EaseType.spring));
            iTween.ScaleTo(button2, iTween.Hash("scale", new Vector3(0.7f, 0.7f, 0.7f), "time", 0.7f, "delay", 0f, "easetype", iTween.EaseType.spring));

            Vector3 startingPosButton1 = button1.transform.position;

            iTween.MoveTo(button1, iTween.Hash("position", button2.transform.position, "time", 1f, "delay", 1f, "easetype", iTween.EaseType.easeOutBounce));
            iTween.MoveTo(button2, iTween.Hash("position", startingPosButton1, "time", 1f, "delay", 1f, "easetype", iTween.EaseType.easeOutBounce));

            iTween.ScaleTo(button1, iTween.Hash("scale", new Vector3(1f, 1f, 1f), "time", 1f, "delay", 2f, "easetype", iTween.EaseType.spring));
            iTween.ScaleTo(button2, iTween.Hash("scale", new Vector3(1f, 1f, 1f), "time", 1f, "delay", 2f, "easetype", iTween.EaseType.spring));
        }

        public void EndSolution () {
            foreach (GameCell cell in cells) {
                cell.ShowButton();
            }
            _isSolving = false;
            UIManager.Instance.DisableButtonGo();
            UIManager.Instance.DisableButtonReady();
            StopCoroutine(_timerCoroutine);

            if (Data.DataManager.Instance.Difficulty.Perfectionist == true || Data.DataManager.Instance.Difficulty.RushMode == true) {
                if (_numOfClicks == gridSize)
                    AudioManager.Instance.PlayObjectiveAchieved();
            }else {
                AudioManager.Instance.PlayObjectiveAchieved();
            }
            CalculateScore();
            CheckAchievements();
            GetPoints();
            Data.DataManager.Instance.Save();
            GameManager.Instance.EndLevel();
        }

        void GetPoints () {
           Data.DataManager.Instance.AddPoints(_score);
        }

        void PrepareGrid () {
            _currentIndex = 0;
            _numOfClicks = 0;
            GameCell [ ] cellsFound;
            cellsFound = GameObject.FindObjectsOfType<GameCell>();

            gridSize = cellsFound.Length;
            cells = new List<GameCell>(cellsFound);

            GenerateList();

            for (int i = 0; i < gridSize; i++) {
                cells [ i ].Index = i;
                cells [ i ].Value = PickFromList();
            }

            cells.Sort((p1, p2) => p1.Value.CompareTo(p2.Value));
            if (Data.DataManager.Instance.Difficulty.Decrescent == true) {
                cells.Reverse();
            }

            UIManager.Instance.EnableButtonReady();
            UIManager.Instance.DisableButtonGo();
        }

        void GenerateList () {
            if (Data.DataManager.Instance.Difficulty.HighValues == true) {
                for (int i = 1000; i < 9999; i++) {
                    valuesList.Add(i);
                }
            } else {
                for (int i = 0; i < gridSize; i++) {
                    valuesList.Add(i);
                }
            }
        }

        int PickFromList () {
            int selectedIndex = UnityEngine.Random.Range(0, valuesList.Count);
            int value = valuesList [ selectedIndex ];
            valuesList.RemoveAt(selectedIndex);
            return value;
        }

        public void ButtonClick (int cellValue) {
            if (_isSolving == false) return;

            if (cells [ _currentIndex ].Value == cellValue) {
                cells [ _currentIndex ].DisableButton();
                _currentIndex++;
                _numOfClicks++;
                _rushModeTimer = 0;
                AudioManager.Instance.PlayOnClickCorrect();
            } else {
                AudioManager.Instance.PlayOnClickWrong();
                _numOfClicks++;
                if (Data.DataManager.Instance.Difficulty.Perfectionist == true) {
                    EndSolution();
                }
            }

            if (_currentIndex == cells.Count) {
                EndSolution();
            }

            UIManager.Instance.UpdateTextNumOfClicks(_numOfClicks);
        }

        IEnumerator RushModeTimerControl () {
            float rushModeMaxTime = 5f;
            _rushModeTimer = 0;

            while (_isSolving) {
                _rushModeTimer += Time.deltaTime;
                if (_rushModeTimer >= rushModeMaxTime) {
                    AudioManager.Instance.PlayTimeOver();
                    EndSolution();
                }
                yield return null;
            }

            yield return null;
        }

        IEnumerator UpdateTimer () {
            while (true) {
                yield return null;
                timer += Time.deltaTime;
                UIManager.Instance.UpdateTextTime(timer);
            }
        }

        private void CalculateScore () {
            //( dimensão x dimensão)³ x(tentativas / total) x 1000 x(1 / time in miliseconds)

            float gridScore = (float) (gridSize * gridSize * gridSize * gridSize) ;
            if (Data.DataManager.Instance.Difficulty.HighValues == true) {
                gridScore *= 2.5f;
            }
            float efficiencyScore = (float) gridSize / _numOfClicks ;
            if (Data.DataManager.Instance.Difficulty.Perfectionist == true || Data.DataManager.Instance.Difficulty.RushMode == true) {
                if (_numOfClicks != gridSize)
                    efficiencyScore = 0;
            } else if (Data.DataManager.Instance.Difficulty.LetMeClick == true) {
                efficiencyScore = 0.5f;
            }
            float timeScore = (float)  1 / ( timer * 1000 );
            if (Data.DataManager.Instance.Difficulty.AlwaysReady == true) {
                timeScore *= 2.5f;
            }

            _score = (int) ( ( gridScore * efficiencyScore * 250 * timeScore ) );

        }

        private void CheckAchievements () {
            if (gridSize == _numOfClicks) {
                AchievementManager.Instance.SetLevelAchievement(gridSize);
            }
        }

        void DisableCells () {
            foreach (GameCell cell in cells) {
                cell.DisableButton();
            }
        }

        void EnableCells () {
            foreach (GameCell cell in cells) {
                cell.EnableButton();
            }
        }
    }
}