using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace LevelManagement
{
    public class UIManager :MonoBehaviour
    {
        private static UIManager _instance;

        public static UIManager Instance { get { return _instance; } }

        [SerializeField]
        TextMeshProUGUI clicksText;

        [SerializeField]
        TextMeshProUGUI timerText;

        [SerializeField]
        Button buttonReady;

        [SerializeField]
        Button buttonGo;

        [SerializeField]
        TextMeshProUGUI orderText;

        private void Awake () {
            if (_instance != null) {
                Destroy(gameObject);
            } else {
                _instance = this;
            }
            orderText.gameObject.SetActive(false);
        }

        private void OnDestroy () {
            if (_instance == this) {
                _instance = null;
            }
        }

        public void UpdateTextNumOfClicks (int i) {
            clicksText.text = i.ToString() + "/" + LevelManager.Instance.GridSize;
        }

        public void UpdateTextTime (float time) {
            float timeInMiliseconds = ( time * 1000 );
            float minutes = 0;
            float seconds = 0;
            float miliseconds = timeInMiliseconds % 1000;

            if (timeInMiliseconds >= 1000) {
                seconds = Mathf.Floor(time); //timeInMiliseconds / 1000;
                if (seconds >= 60) {
                    minutes = seconds / 60;
                    seconds = seconds % 60;
                }
            }

            string x = minutes.ToString("00") + ":" + seconds.ToString("00") + ":" + miliseconds.ToString("00");
            //string x = timeInMiliseconds.ToString();
            //string x = timeInMiliseconds.ToString();

            timerText.text = x;
        }

        public void SetOrderTextCrescent() {
            orderText.text = "Crescent";
        }

        public void SetOrderTextDecrescent () {
            orderText.text = "Decrescent";
        }

        public void EnableOrderText() {
            orderText.gameObject.SetActive(true);
        }

        public void DisableOrderText () {
            orderText.gameObject.SetActive(false);
        }

        public void EnableButtonReady () {
            buttonReady.interactable = true;
        }

        public void DisableButtonReady () {
            buttonReady.interactable = false;
        }

        public void EnableButtonGo () {
            buttonGo.interactable = true;
        }

        public void DisableButtonGo () {
            buttonGo.interactable = false;
        }
    }
}
