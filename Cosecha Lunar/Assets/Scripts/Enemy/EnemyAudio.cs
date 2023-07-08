using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAudio : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip attackClip;
    public AudioClip hurtClip;
    public AudioClip shotClip;
    public AudioClip spawnClip;

    public AudioClip jumpClip;
    public AudioClip fallClip;
    public AudioClip dashClip;
    //int randomSound=1;
    private void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }
    public void PlayHurt()
    {
        audioSource.PlayOneShot(hurtClip, Random.Range(0.4f, 0.65f));
    }
    public void PlayAttack()
    {
        audioSource.PlayOneShot(attackClip, Random.Range(0.5f, 0.75f));
    }
    public void PlayShot()
    {
        audioSource.PlayOneShot(shotClip, Random.Range(0.5f, 0.75f));
    }
    public void PlaySpawn()
    {
        audioSource.PlayOneShot(spawnClip, Random.Range(0.5f, 0.75f));
    }
    public void PlayDeath()
    {
        audioSource.PlayOneShot(spawnClip, Random.Range(0.5f, 0.75f));
    }
}
