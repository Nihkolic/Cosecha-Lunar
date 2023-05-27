using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [Header("Pause")]
    [SerializeField] private GameObject pauseMenu;
    public static bool GAME_IS_PAUSED = false;
    
    [Header("Keybinds")]
    [SerializeField] private KeyCode ExitKey = KeyCode.Escape;

    [Header("Panels")]
    [SerializeField] private GameObject quitPanel;
    [SerializeField] private GameObject optionsPanel;
    [SerializeField] private GameObject pausePanel;

    private void Start()
    {
        Resume();
    }
    private void Update()
    {
        if (Input.GetKeyDown(ExitKey) && LevelChange.GAME_CANT_BE_PAUSED==false)
        {
            if (GAME_IS_PAUSED)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
        if (Input.GetMouseButtonDown(1) && GAME_IS_PAUSED)
        {
            BackToPause();
        }
    }
    public void Retry()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
    public void ChangeScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        if(currentSceneIndex==0)
            SceneManager.LoadScene(1);
        else if(currentSceneIndex == 1)
            SceneManager.LoadScene(0);
    }
    public void Resume()
    {
        pauseMenu.SetActive(false);
        optionsPanel.SetActive(false);
        pausePanel.SetActive(false);
        quitPanel.SetActive(false);

        ResumeSettings();
    }
    public void Pause()
    {
        pauseMenu.SetActive(true); 
        optionsPanel.SetActive(false);
        pausePanel.SetActive(true);
        quitPanel.SetActive(false);

        PauseSettings();
    }
    public void PauseSettings()
    {
        Time.timeScale = 0f;
        GAME_IS_PAUSED = true;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public void ResumeSettings()
    {
        Time.timeScale = 1f;
        GAME_IS_PAUSED = false;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    public void ToQuit()
    {
        quitPanel.SetActive(true);
    }
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("quit");
    }
    public void BackToPause()
    {
        optionsPanel.SetActive(false);
        pausePanel.SetActive(true);
    }
    public void BackFromQuitPanel()
    {
        quitPanel.SetActive(false);

    }
    public void ChangeScene(int index)
    {
        Time.timeScale = 1f;
        GAME_IS_PAUSED = false;

        SceneManager.LoadScene(index);
    }
    public void ToOptions()
    {
        optionsPanel.SetActive(true);
        pausePanel.SetActive(false);
    }
}
