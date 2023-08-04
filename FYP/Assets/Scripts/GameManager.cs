using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    #region Variable
    public static GameManager gameManager;
    public AudioSource UISound;
    public AudioSource BGM;
    private Tween _tween;
    public List<RectTransform> UItransform = new List<RectTransform>();
    public List<CanvasGroup> UIFadetrans = new List<CanvasGroup>();
    public List<GameObject> UIGameObjects = new List<GameObject>();
    public bool isLoadingScene;
    #endregion
    

    private void Awake()
    {
        gameManager = this;
        NotLoad();
    }

    private void Start()
    {
        UIGameObjects[2].SetActive(false);
        UIGameObjects[3].SetActive(false);
        for (int i = 0; i < 2; i++)
        {
            UIGameObjects[i].SetActive(true);
        }
        
    }

    private void Update()
    {
        if (UIFadetrans[0].alpha==0)
        {
            UIGameObjects[2].SetActive(true);
            ChooseCharacterMoveAndFade();
        }
    }

    public void PlayButtomSound()
    {
        UISound.Play();
    }

    public void NotLoad()
    {
        DontDestroyOnLoad(gameManager);
    }

    public void ChangeScene()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void UIMove()
    {
        foreach (var UImove in UItransform)
        {
            UImove.DOMoveX(2000, 2);
        }
    }

    public void UIFade(float alpha, float duration, TweenCallback onEnd)
    {
        foreach (var uiFadetran in UIFadetrans)
        {
            uiFadetran.DOFade(alpha, duration);
        }
    }

    public void UIFadeStart()
    {
        UIFade(0,1, () =>
        {
            foreach (var uiFadetran in UIFadetrans)
            {
                uiFadetran.blocksRaycasts = true;
                uiFadetran.interactable = true;
            }
        });
    }

    public void ChooseCharacterMoveAndFade()
    {
        UIGameObjects[2].transform.DOMoveY(300, 2);
        UIFade(1,3, () => { });
    }

    public void Confirm()
    {
        UIGameObjects[3].SetActive(true);
    }

    public void NoButtom()
    {
        UIGameObjects[3].SetActive(false);
    }

    public void YesButton()
    {
        SceneManager.LoadScene("Loading");
        
    }





}
