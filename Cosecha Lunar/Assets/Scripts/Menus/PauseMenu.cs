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
        if (Input.GetKeyDown(ExitKey))
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

        Time.timeScale = 1f;
        GAME_IS_PAUSED = false;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    void Pause()
    {
        pauseMenu.SetActive(true);
        optionsPanel.SetActive(false);
        pausePanel.SetActive(true);
        quitPanel.SetActive(false);

        Time.timeScale = 0f;
        GAME_IS_PAUSED = true;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
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
