using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonFade : MonoBehaviour
{
    [SerializeField] CanvasGroup starMenu;
    [SerializeField] GameObject UI;
    [SerializeField] private float speed = 1;
    [SerializeField] RectTransform rectTransform;
    

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
            Vector2 targetPosition = new Vector2(440f, 0f);
            rectTransform.anchoredPosition = Vector2.Lerp(
                rectTransform.anchoredPosition, targetPosition, speed * Time.deltaTime);
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
