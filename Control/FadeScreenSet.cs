using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeScreenSet : MonoBehaviour
{
    public Image blackFade;
    // Start is called before the first frame update
    void Start()
    {
        blackFade.canvasRenderer.SetAlpha(0.0f);
        fadeOut();
    }

    // Update is called once per frame
    void fadeOut()
    {
        blackFade.CrossFadeAlpha(1, 5, false);
    }
}
