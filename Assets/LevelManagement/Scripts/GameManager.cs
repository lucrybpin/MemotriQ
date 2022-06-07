using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using LevelManagement;

public class GameManager :MonoBehaviour
{

    //reference to objective
    private Objective _objective;

    private bool _isGameOver;
    public bool IsGameOver { get { return _isGameOver; } }

    private bool _ended = false;

    [SerializeField]
    private string _levelSelected;

    public string LevelSelected { set { _levelSelected = value; } get { return _levelSelected; } }

    private static GameManager _instance;

    public static GameManager Instance { get { return _instance; } }

    [SerializeField]
    private TransitionFader _endTransitionPrefab;


    private void Awake () {
        _objective = Object.FindObjectOfType<Objective>();

        if (_instance != null) {
            Destroy(gameObject);
        } else {
            _instance = this;
        }
    }

    private void Start () {
       
    }

    private void OnDestroy () {
        if (_instance == this) {
            _instance = null;
        }
    }

    public void EndLevel () {
        _isGameOver = true;
        _ended = true;
        StartCoroutine(WinRoutine());
    }

    private IEnumerator WinRoutine() {
        //TransitionFader.PlayTransition(_endTransitionPrefab);
        float fadeDelay = ( _endTransitionPrefab != null ) ? 
            _endTransitionPrefab.Delay + _endTransitionPrefab.FadeOnDuration : 0;
        yield return new WaitForSeconds(fadeDelay);
        WinMenu.Instance.SetScore(LevelManager.Instance.Score);
        WinMenu.Open();
    }

    private void Update () {
        if (_objective != null && _objective.IsComplete && _ended == false) {
            EndLevel();
        }
    }

    private void FindGridSize() {
        GameObject boardCanvas = GameObject.FindObjectOfType<BoardCanvas>().gameObject;
        int count = 0;

        foreach (Transform child in transform) {
            if (child.GetComponent<GameCell>() != null) {
                count++;
            }
        }
    }

}
