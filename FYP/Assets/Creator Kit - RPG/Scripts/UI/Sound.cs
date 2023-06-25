using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    public AudioSource playerAudioSource;
    public AudioClip onSelect;
    public AudioClip onClick;

    public void HoverSound()
    {
        playerAudioSource.PlayOneShot(onSelect);
    }
    public void ClickSound()
    {
        playerAudioSource.PlayOneShot(onClick);
    }
    
    
}
