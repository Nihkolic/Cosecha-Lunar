using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Ending : MonoBehaviour
{
    public GameObject e1, e2, e3;

    [SerializeField] private TMP_Text totalText;

    void Start()
    {
        e1.SetActive(true);
        e2.SetActive(false);
        e3.SetActive(false);

        Time.timeScale = 0f;
        PauseMenu.GAME_IS_PAUSED = false;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        totalText.text = PlayerPrefs.GetInt("Score").ToString();
    }
    public void ToMainMenu()
    {
        Time.timeScale = 1f;
        PauseMenu.GAME_IS_PAUSED = false;

        SceneManager.LoadScene(0);
    }
    public void To_02()
    {
        e1.SetActive(false);
        e2.SetActive(true);
        e3.SetActive(false);
    }
    public void To_03()
    {
        e1.SetActive(false);
        e2.SetActive(false);
        e3.SetActive(true);
    }
}
