using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChange : MonoBehaviour
{
    [SerializeField] private ResultsMenu pointSystem;

    [SerializeField] private GameObject _player;
    [SerializeField] private Transform position_0;
    [SerializeField] private Transform position_1;
    [SerializeField] private Transform position_2;
    [SerializeField] private Transform position_3;

    [SerializeField] private GameAudio gameAudio;

    //[SerializeField] private GameObject playerBody;
    //[SerializeField] private GameObject playerCamera;

    
    private Transform _nextPosition;

    [SerializeField] private GameObject deathPanel;
    [SerializeField] private PauseMenu pauseMenu;

    public void PlayerDeath()
    {
        deathPanel.SetActive(true);
        pauseMenu.PauseSettings();
        NewLevelChange.GAME_CANT_BE_PAUSED = true;
    }
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.K))
        {
            PlayerDeath();
        }
    }
    public void Continue_Button() //Player Respawn
    {
        PlayerHealth.PLAYER_IS_DEAD = false;
        NewLevelChange.GAME_CANT_BE_PAUSED = false;
        pauseMenu.ResumeSettings();
        deathPanel.SetActive(false);

        if (NewLevelChange.CURRENT_LEVEL == 0)
        {
            _player.transform.position = position_0.transform.position;
            //gameAudio.PlayBackground(1);
        }
        if (NewLevelChange.CURRENT_LEVEL == 1)
        {
            _player.transform.position = position_1.transform.position;
            //gameAudio.PlayBackground(1);
        }
        if (NewLevelChange.CURRENT_LEVEL == 2)
        {
            _player.transform.position = position_2.transform.position;
            //gameAudio.PlayBackground(2);
        }
        if (NewLevelChange.CURRENT_LEVEL == 3)
        {
            _player.transform.position = position_3.transform.position;
        }
    }
    public void ToNextLevel(int currentArea)
    {
        if (currentArea == 0)
        {
            pointSystem.ToResultsMenu(0);
            //_player.transform.position = position_1.transform.position;
            NewLevelChange.CURRENT_LEVEL = 1;
            Debug.Log(0 + " End");

        }
        if (currentArea == 1)
        {
            pointSystem.ToResultsMenu(1);
            //_player.transform.position = position_2.transform.position;
            NewLevelChange.CURRENT_LEVEL = 2;
            Debug.Log(1 + " End");

        }
        if (currentArea == 2)
        {
            pointSystem.ToResultsMenu(2);
            //_player.transform.position = position_3.transform.position;
            NewLevelChange.CURRENT_LEVEL = 3;

            
            
            Debug.Log(2 + " End");
        }
        if (currentArea == 3)
        {

            pointSystem.SaveScore();
            GameEnd();

            Debug.Log(3 + " End");
        }
        NewLevelChange.GAME_CANT_BE_PAUSED = true;
    }
    public void GameEnd()
    {
        SceneManager.LoadScene(2);

        //pauseMenu.PauseSettings();

        //GAME_CANT_BE_PAUSED = true;
    }
}
