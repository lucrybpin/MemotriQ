using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdManager : MonoBehaviour
{
    private string _currentPlacement;

    private static AdManager _instance;

    public static AdManager Instance { get { return _instance; } }

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


    public void ShowRewardedAd(string placement) {

        _currentPlacement = placement;

        if (Advertisement.IsReady(placement)) {

            var options = new ShowOptions { resultCallback = HandleShowResult };
            Advertisement.Show(placement, options);

        }
    }

    private void HandleShowResult(ShowResult result) {
        switch (result) {
            case ShowResult.Failed:
            //Falhou
            Debug.LogError("The ad failed to be shown.");
            break;
            case ShowResult.Skipped:
            //Pulou
            Debug.Log("The ad was skipped");
            break;
            case ShowResult.Finished:
            //Finalizou
            
            if (_currentPlacement == "video") {
                Debug.Log("Placement: video Ad was successfully shown.");
            } else if (_currentPlacement == "rewardedVideo") {
                Debug.Log("Placement: rewardedVideo Ad was successfully shown.");
            }
            break;
            default:
            break;
        }
    }
}
