using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loading : MonoBehaviour
{
    
    void Update()
    {
        if (!GameManager.gameManager.isLoadingScene)
        {
            GameManager.gameManager.BGM.Stop();
        }
    }
}
