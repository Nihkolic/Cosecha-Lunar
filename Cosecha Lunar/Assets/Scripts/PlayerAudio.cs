using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudio : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip healClip;
    public AudioClip hurtClip;

    public AudioClip[] stepsClips;
    public AudioClip jumpClip;
    public AudioClip fallClip;
    public AudioClip dashClip;

    public AudioClip attackClip;
    public AudioClip shotClip;
    public AudioClip furyShotClip;
    //int randomSound=1;

    public void PlayHurt()
    {
        audioSource.PlayOneShot(hurtClip, Random.Range(0.4f, 0.65f));
    }
    public void PlayHeal()
    {
        audioSource.PlayOneShot(healClip, Random.Range(0.5f, 0.75f));
    }
    public void PlaySteps()
    {
        //audioSource.PlayOneShot(stepsClip, Random.Range(0.05f,0.2f));
        //audioSource.PlayOneShot(stepsClip, Random.Range(0.7f, 0.7f)); //0.5

        if (!audioSource.isPlaying)
        {
            audioSource.clip = stepsClips[Random.Range(0, stepsClips.Length)];
            audioSource.volume = Random.Range(0.15f, 0.2f);
            audioSource.PlayDelayed(0.15f);
        }

    }
    public void PlayJump()
    {
        audioSource.PlayOneShot(jumpClip, 0.75f);
    }
    public void PlayFall()
    {
        audioSource.PlayOneShot(fallClip, Random.Range(0.15f, 0.2f));
    }
    public void PlayDash()
    {
        audioSource.PlayOneShot(dashClip, Random.Range(0.5f, 0.75f));
    }
    public void PlayAttack()
    {
        audioSource.PlayOneShot(attackClip, Random.Range(0.5f, 0.75f));
    }
    public void PlaySHot()
    {
        audioSource.PlayOneShot(shotClip, Random.Range(0.5f, 0.75f));
    }
    public void PlayFurySHot()
    {
        audioSource.PlayOneShot(furyShotClip, Random.Range(0.5f, 0.75f));
    }
}
