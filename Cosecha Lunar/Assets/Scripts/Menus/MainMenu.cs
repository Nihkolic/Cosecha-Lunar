using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject mainPanel, creditsPanel, scorePanel, optionsPanel, quitPanel;
    private bool isQuitPanelUp;

    [Header("Audio")]
    [SerializeField] private AudioClip enterClip;
    [SerializeField] private AudioClip backClip;
    private AudioSource _audioSource;

    [Header("Keybinds")]
    [SerializeField] private KeyCode ExitKey = KeyCode.Escape;

    private void Start()
    {
        ChangePanel(true, false, false, false, false);
        _audioSource = GetComponent<AudioSource>();
        isQuitPanelUp = false;
    }
    private void Update()
    {
        if (Input.GetKeyDown(ExitKey) && !isQuitPanelUp)
        {
            ToQuit();
        }
        if (Input.GetMouseButtonDown(1))
        {
            BackToMain();
        }
    }
    private void ChangePanel(bool main, bool credits, bool score, bool options, bool quit)
    {
        mainPanel.SetActive(main);
        creditsPanel.SetActive(credits);
        scorePanel.SetActive(score);
        optionsPanel.SetActive(options);
        quitPanel.SetActive(quit);
    }
    public void ToCredits()
    {
        ChangePanel(false, true, false, false, false);
    }
    public void ToScore()
    {
        ChangePanel(false, false, true, false, false);
    }
    public void ToOptions()
    {
        ChangePanel(false, false, false, true, false);
    }
    public void BackToMain()
    {
        ChangePanel(true, false, false, false, false);
    }
    public void BackFromQuitPanel()
    {
        quitPanel.SetActive(false);
        isQuitPanelUp = false;
    }
    public void ChangeScene(int index)
    {
        SceneManager.LoadScene(index);
    }
    public void ToQuit()
    {
        quitPanel.SetActive(true);
        isQuitPanelUp = true;
    }
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("quit");
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
