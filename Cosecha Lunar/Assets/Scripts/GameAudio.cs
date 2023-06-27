using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAudio : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip level1CLip;
    public AudioClip level2CLip;
    public AudioClip level3CLip;
    public AudioClip resultsCLip;
    public AudioClip gameOverClip;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void PlayBackground(int level)
    {/*
        if (level == 1)
        {
            audioSource.clip = level1CLip;
            audioSource.Play();

        }
        else if (level == 2)
        {
            audioSource.clip = level2CLip;
            audioSource.Play();
        }
        else if (level == 3)
        {
            audioSource.clip = level3CLip;
            audioSource.Play();
        }*/
    }
    public void PlayResults()
    {
        //audioSource.clip = resultsCLip;
        //audioSource.Play();
    }
}
