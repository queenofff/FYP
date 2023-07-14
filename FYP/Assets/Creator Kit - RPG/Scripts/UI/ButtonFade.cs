using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonFade : MonoBehaviour
{
    [SerializeField] CanvasGroup starMenu;
    [SerializeField] GameObject UI;

    private float fadeEndTime = 0.0f;
    private float fadeStartTime = 1.0f;
    private float fadeTimer = 1.0f;

    private bool fadeIn = false;
    private float maths = 0.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        starMenu.alpha = fadeStartTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (fadeIn != false)
        {
            fadeTimer -= Time.deltaTime;
            starMenu.alpha = fadeTimer;
        }

        if (fadeTimer <= fadeEndTime)
        {
            UI.SetActive(false);
        }
    }

    public void StartFadeMenu()
    {
        fadeIn = true;
    }
}
