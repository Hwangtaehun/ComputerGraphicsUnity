using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffect : MonoBehaviour
{
    public AudioClip audiohurt;
    public AudioClip audiojump;
    public AudioClip audioslide;
    AudioSource audioSource;

    private void Awake()
    {
        this.audioSource = GetComponent<AudioSource>();
    }

    public void PlaySound(string action)
    {
        switch(action)
        {
            case "Jump":
                audioSource.clip = audiojump;
                break;
            case "Slide":
                audioSource.clip = audioslide;
                break;
            case "Hurt":
                audioSource.clip = audiohurt;
                break;
        }
        audioSource.Play();
    }
}
