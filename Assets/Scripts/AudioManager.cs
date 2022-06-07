using LevelManagement.Data;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioManager _instance;

    public static AudioManager Instance { get { return _instance; } }

    [SerializeField]
    AudioClip blockClickWrong;

    [SerializeField]
    AudioClip blockClickCorrectClip;

    [SerializeField]
    AudioClip [ ] readyClip;

    [SerializeField]
    AudioClip [ ] goClip;

    [SerializeField]
    AudioClip [ ] objectiveAchievedClip;

    [SerializeField]
    AudioClip [ ] timeOverClip;

    [SerializeField]
    AudioClip buttonClickClip;

    [SerializeField]
    AudioClip buttonClick2Clip;

    [SerializeField]
    List<AudioClip> musicClips = new List<AudioClip>();

    [SerializeField]
    List<AudioClip> sfxClips = new List<AudioClip>();

    [SerializeField]
    float musicVolume;

    [SerializeField]
    float sfxVolume;

    private DataManager _dataManager;

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

    private void Start () {
        //musicClips.Add();
        sfxClips.Add(buttonClickClip);
        sfxClips.Add(buttonClick2Clip);
        sfxClips.Add(blockClickWrong);
        sfxClips.Add(blockClickCorrectClip);
        foreach (AudioClip audioClip in readyClip)
            sfxClips.Add(audioClip);
        foreach (AudioClip audioClip in goClip)
            sfxClips.Add(audioClip);
        foreach (AudioClip audioClip in objectiveAchievedClip)
            sfxClips.Add(audioClip);
        foreach (AudioClip audioClip in timeOverClip)
            sfxClips.Add(audioClip);

        _dataManager = Object.FindObjectOfType<DataManager>();
    }

    public void PlayOnClickCorrect() {
        StartCoroutine(PlaySoundCoroutine(blockClickCorrectClip));
    }

    public void PlayOnClickWrong () {
        StartCoroutine(PlaySoundCoroutine(blockClickWrong));
    }

    public void PlayReady() {
        StartCoroutine(PlaySoundCoroutine(readyClip[0])); //0 = female
    }

    public void PlayGo() {
        StartCoroutine(PlaySoundCoroutine(goClip [ 0 ])); //0 = female
    }

    public void PlayObjectiveAchieved() {
        StartCoroutine(PlayObjectiveAchievedCoroutine());
    }

    public void PlayTimeOver() {
        StartCoroutine(PlaySoundCoroutine(timeOverClip[0]));
    }

    public void PlayButtonClick() {
        StartCoroutine(PlaySoundCoroutine(buttonClickClip));
    }

    public void PlayButtonClick2 () {
        StartCoroutine(PlaySoundCoroutine(buttonClick2Clip));
    }

    public IEnumerator PlayObjectiveAchievedCoroutine() {
        yield return new WaitForSeconds(1);
        Debug.Log("Objective Achieved");
        yield return PlaySoundCoroutine(objectiveAchievedClip[0]);

        //AudioSource audioSource = gameObject.AddComponent<AudioSource>();
        //audioSource.clip = voiceClips [ 2 ];
        //audioSource.Play();
    }

    private IEnumerator PlaySoundCoroutine (AudioClip audioclip) {
        
        AudioSource audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = audioclip;
        AudioClip xFound = sfxClips.Find((x) => x == audioclip);
        if (xFound != null) {
            audioSource.volume = _dataManager.SfxVolume;
        }

        audioSource.Play();
        yield return new WaitUntil(() => audioSource.isPlaying == false);
        Destroy(audioSource);
    }
}
