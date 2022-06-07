using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuHeaderEffect : MonoBehaviour
{
    [SerializeField]
    List<MaskableGraphic> letters;

    [SerializeField]
    protected float _solidAlpha = 1;

    [SerializeField]
    protected float _clearAlpha = 0f;

    private void Start () {
        //StartEffect();
    }

    public void StartEffect() {
        for (int i = 0; i < letters.Count; i++) {
            FadeOff(letters [ i ]);
        }
        StartCoroutine(LetterEffectCoroutine());
    }

    private IEnumerator LetterEffectCoroutine() {
        yield return null;
        while (true) {
            for (int i = 0; i < letters.Count; i++) {
                FadeOn(letters [ i ]);
                yield return new WaitForSeconds(0.2f);
                FadeOff(letters [ i ]);
            }
        }
    }

    protected void SetAlpha (MaskableGraphic target, float alpha) {
            target.canvasRenderer.SetAlpha(alpha);
    }

    public void FadeOff (MaskableGraphic target) {
        SetAlpha(target, _solidAlpha);
        Fade(target, _clearAlpha, 0.5f);
    }

    public void FadeOn (MaskableGraphic target) {
        SetAlpha(target, _clearAlpha);
        Fade(target, _solidAlpha, 0.5f);
    }

    private void Fade (MaskableGraphic target, float targetAlpha, float duration) {
        if (target != null) {
            target.CrossFadeAlpha(targetAlpha, duration, true);
        }
    }
}
