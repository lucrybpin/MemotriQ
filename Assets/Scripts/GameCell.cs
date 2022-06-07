using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameCell : MonoBehaviour
{
    [SerializeField]
    int index;
    [SerializeField]
    int value;

    private TextMeshProUGUI text;

    public int Index {
        get => index;
        set {
            index = value;
        }
    }
    public int Value {
        get => value;
        set {
            this.value = value;
        }
    }

    public void OnClick() {
        LevelManagement.LevelManager.Instance.ButtonClick(value);
        //Handheld.Vibrate();
    }


    public void EnableButton() {
        Debug.Log("Enabled Button");
        GetComponent<Button>().interactable = true;
    }

    public void DisableButton () {
        Debug.Log("Disabled Button");
        GetComponent<Button>().interactable = false;
    }

    public void HideButton() {
        this.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "";
    }

    public void ShowButton() {
        this.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = this.value.ToString();
    }
}
