using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChange : MonoBehaviour
{
    [SerializeField] private ResultsMenu pointSystem;
    public static bool GAME_CANT_BE_PAUSED = false;

    [SerializeField] private GameObject _player;
    [SerializeField] private Transform position_0;
    [SerializeField] private Transform position_1;
    [SerializeField] private Transform position_2;
    [SerializeField] private Transform position_3;

    [SerializeField] private GameAudio gameAudio;

    //[SerializeField] private GameObject playerBody;
    //[SerializeField] private GameObject playerCamera;

    public static int CURRENT_LEVEL;
    private Transform _nextPosition;

    [SerializeField] private GameObject deathPanel;
    [SerializeField] private PauseMenu pauseMenu;

    private void Awake()
    {
        //_player = GameObject.FindWithTag("Player");
        _player.transform.position = position_0.transform.position;

        CURRENT_LEVEL = 0;

        deathPanel.SetActive(false);
    }
    public void PlayerDeath()
    {
        deathPanel.SetActive(true);
        pauseMenu.PauseSettings();
        GAME_CANT_BE_PAUSED = true;
    }
    private void Update()
    {
      
    }
    public void Continue_Button() //Player Respawn
    {
        PlayerHealth.PLAYER_IS_DEAD = false;
        GAME_CANT_BE_PAUSED = false;
        pauseMenu.ResumeSettings();
        deathPanel.SetActive(false);

        if (CURRENT_LEVEL == 0)
        {
            _player.transform.position = position_0.transform.position;
            //gameAudio.PlayBackground(1);
        }
        if (CURRENT_LEVEL == 1)
        {
            _player.transform.position = position_1.transform.position;
            //gameAudio.PlayBackground(1);
        }
        if (CURRENT_LEVEL == 2)
        {
            _player.transform.position = position_2.transform.position;
            //gameAudio.PlayBackground(2);
        }
        if (CURRENT_LEVEL == 3)
        {
            _player.transform.position = position_3.transform.position;
        }
    }
    public void ToNextLevel(int currentArea)
    {
        if (currentArea == 0)
        {
            pointSystem.ToResultsMenu(0);
            _player.transform.position = position_1.transform.position;
            CURRENT_LEVEL = 1;
            Debug.Log(0 + " End");

        }
        if (currentArea == 1)
        {
            pointSystem.ToResultsMenu(1);
            _player.transform.position = position_2.transform.position;
            CURRENT_LEVEL = 2;
            Debug.Log(1 + " End");

        }
        if (currentArea == 2)
        {
            //GameEnd();
            pointSystem.ToResultsMenu(2);
            _player.transform.position = position_3.transform.position;
            CURRENT_LEVEL = 3;

            
            
            Debug.Log(2 + " End");
        }
        if (currentArea == 3)
        {

            pointSystem.SaveScore();
            GameEnd();

            Debug.Log(3 + " End");
        }
        GAME_CANT_BE_PAUSED = true;
    }
    public void GameEnd()
    {
        SceneManager.LoadScene(2);

        //pauseMenu.PauseSettings();

        //GAME_CANT_BE_PAUSED = true;
    }/*
    private void LevelChangeDebug()
    {
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            _player.GetComponent<PlayerCombat>().BlasterRevert();
            _player.transform.position = position_0.transform.position;
            print("Nivel 0");
            CURRENT_LEVEL = 0;
            //gameAudio.PlayBackground(1);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            _player.GetComponent<PlayerCombat>().BlasterGet();
            _player.transform.position = position_1.transform.position;
            print("Nivel 1");
            CURRENT_LEVEL = 1;
            //gameAudio.PlayBackground(1);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            _player.GetComponent<PlayerCombat>().BlasterGet();
            _player.transform.position = position_2.transform.position;
            print("Nivel 2");
            CURRENT_LEVEL = 2;
            //gameAudio.PlayBackground(2);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            _player.GetComponent<PlayerCombat>().BlasterGet();
            _player.transform.position = position_3.transform.position;
            print("Nivel 3");
            CURRENT_LEVEL = 3;
            //gameAudio.PlayBackground(3);
        }
    }*/
    public void LevelChangeDebug(int num)
    {
        if (num == 0)
        {
            _player.GetComponent<PlayerCombat>().BlasterRevert();
            _player.transform.position = position_0.transform.position;
            print("Nivel 0");
            CURRENT_LEVEL = 0;
            //gameAudio.PlayBackground(1);
        }
        if (num == 1)
        {
            _player.GetComponent<PlayerCombat>().BlasterGet();
            _player.transform.position = position_1.transform.position;
            print("Nivel 1");
            CURRENT_LEVEL = 1;
            //gameAudio.PlayBackground(1);
        }
        if (num == 2)
        {
            _player.GetComponent<PlayerCombat>().BlasterGet();
            _player.transform.position = position_2.transform.position;
            print("Nivel 2");
            CURRENT_LEVEL = 2;
            //gameAudio.PlayBackground(2);
        }
        if (num == 3)
        {
            _player.GetComponent<PlayerCombat>().BlasterGet();
            _player.transform.position = position_3.transform.position;
            print("Nivel 3");
            CURRENT_LEVEL = 3;
            //gameAudio.PlayBackground(3);
        }
    }
}
