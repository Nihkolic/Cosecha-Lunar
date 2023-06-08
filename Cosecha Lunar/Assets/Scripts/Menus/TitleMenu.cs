using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleMenu : MonoBehaviour
{
    private bool isQuitPanelUp;
    [SerializeField] private MainMenu mainMenu; 

    [Header("Audio")]
    [SerializeField] private AudioClip enterClip;
    [SerializeField] private AudioClip backClip;
    private AudioSource _audioSource;

    private void Start()
    {
        mainMenu.ChangePanel(false, false, false, false, false);
        _audioSource = GetComponent<AudioSource>();
        isQuitPanelUp = false;
    }
    private void Update()
    {
        if (Input.anyKey)
        {
            Debug.Log("A key or mouse click has been detected");
            mainMenu.BackToMain();
            Destroy(gameObject);
        }
    }
    public void PlayEnter(bool toPanel)
    {
        if (toPanel)
        {
            //_audioSource.PlayOneShot(enterClip, 0.2f);
        }
        else
        {
            //_audioSource.PlayOneShot(backClip, 0.2f);
        }

    }
}
