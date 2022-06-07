using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuButtonWidthEffect : MonoBehaviour
{
    [Range(0,2)]
    public float lerp;
    [SerializeField]
    float minWidth = 700f;
    [SerializeField]
    float maxWidth = 1200f;



    float _updatedWidth;
    float _desiredWidth;



    RectTransform rectTransform;

    private void Start () {
        rectTransform = GetComponent<RectTransform>();
        _updatedWidth = rectTransform.sizeDelta.x;
    }

    private void Update () {

        if (_updatedWidth > maxWidth - 10f) {
            _desiredWidth = minWidth;
        } else if (_updatedWidth < minWidth + 10f) {
            _desiredWidth = maxWidth;
        }

        _updatedWidth = Mathf.Lerp(_updatedWidth, _desiredWidth, lerp * Time.deltaTime);
        rectTransform.sizeDelta = new Vector2(_updatedWidth, rectTransform.sizeDelta.y);
    }
}
