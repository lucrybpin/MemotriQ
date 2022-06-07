using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Difficulty
{
    [SerializeField]
    private bool _decrescent;
    public bool Decrescent {
        get {
            return _decrescent;
        }
        set {
            _decrescent = value;
        }
    }

    [SerializeField]
    private bool _perfectionist;
    public bool Perfectionist {
        get {
            return _perfectionist;
        }
        set {
            _perfectionist = value;
        }
    }

    [SerializeField]
    private bool _highValues;
    public bool HighValues {
        get {
            return _highValues;
        }
        set {
            _highValues = value;
        }
    }

    [SerializeField]
    private bool _alwaysReady;
    public bool AlwaysReady {
        get {
            return _alwaysReady;
        }
        set {
            _alwaysReady = value;
        }
    }

    [SerializeField]
    private bool _letMeClick;
    public bool LetMeClick {
        get {
            return _letMeClick;
        }
        set {
            _letMeClick = value;
        }
    }

    [SerializeField]
    private bool _rushMode;
    public bool RushMode {
        get {
            return _rushMode;
        }
        set {
            _rushMode = value;
        }
    }

    [SerializeField]
    private bool _simpleShuffle;
    public bool SimpleShuffle {
        get {
            return _simpleShuffle;
        }
        set {
            _simpleShuffle = value;
        }
    }

    [SerializeField]
    private bool _threeShuffle;
    public bool ThreeShuffle {
        get {
            return _threeShuffle;
        }
        set {
            _threeShuffle = value;
        }
    }

    [SerializeField]
    private bool _randomSort;
    public bool RandomSort {
        get {
            return _randomSort;
        }
        set {
            _randomSort = value;
        }
    }

}
