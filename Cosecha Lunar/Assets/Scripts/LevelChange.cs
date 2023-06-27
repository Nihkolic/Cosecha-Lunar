using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelChange : MonoBehaviour
{
    [SerializeField] private PointSystem pointSystem;
    public static bool GAME_CANT_BE_PAUSED = false;

    [SerializeField] private GameObject _player;
    [SerializeField] private Transform position_0;
    [SerializeField] private Transform position_1;
    [SerializeField] private Transform position_2;
    [SerializeField] private Transform position_3;

    [SerializeField] private GameObject endPanel;     //change later

    [SerializeField] private GameAudio gameAudio;

    //[SerializeField] private GameObject playerBody;
    [SerializeField] private GameObject playerCamera;

    public static int CURRENT_LEVEL;
    private Transform _nextPosition;

    [SerializeField] private GameObject deathPanel;
    [SerializeField] private PauseMenu pauseMenu;
    private void Awake()
    {
        //_player = GameObject.FindWithTag("Player");
        _player.transform.position = position_0.transform.position;
        CURRENT_LEVEL = 0;

        endPanel.SetActive(false);
        deathPanel.SetActive(false);

    }
    private void Start()
    {
        
    }
    public void PlayerDeath()
    {
        deathPanel.SetActive(true);
        pauseMenu.PauseSettings();
        GAME_CANT_BE_PAUSED = true;
    }
    private void Update()
    {
        LevelChangeDebug();
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
            gameAudio.PlayBackground(1);
        }
        if (CURRENT_LEVEL == 1)
        {
            _player.transform.position = position_1.transform.position;
            gameAudio.PlayBackground(1);
        }
        if (CURRENT_LEVEL == 2)
        {
            _player.transform.position = position_2.transform.position;
            gameAudio.PlayBackground(2);
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
            pointSystem.ToResultsMenu(2);
            _player.transform.position = position_3.transform.position;
            CURRENT_LEVEL = 3;
            Debug.Log(2 + " End");
        }
        if (currentArea == 3)
        {
            pointSystem.ToResultsMenu(3);
            GameEnd();

            Debug.Log(3 + " End");
        }
        GAME_CANT_BE_PAUSED = true;
    }
    public void GameEnd()
    {
        endPanel.SetActive(true);

        pauseMenu.PauseSettings();

        GAME_CANT_BE_PAUSED = true;
    }
    private void LevelChangeDebug()
    {
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            _player.GetComponent<PlayerCombat>().BlasterRevert();
            _player.transform.position = position_0.transform.position;
            print("Nivel 0");
            CURRENT_LEVEL = 0;
            gameAudio.PlayBackground(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            _player.GetComponent<PlayerCombat>().BlasterGet();
            _player.transform.position = position_1.transform.position;
            print("Nivel 1");
            CURRENT_LEVEL = 1;
            gameAudio.PlayBackground(1);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            _player.GetComponent<PlayerCombat>().BlasterGet();
            _player.transform.position = position_2.transform.position;
            print("Nivel 2");
            CURRENT_LEVEL = 2;
            gameAudio.PlayBackground(2);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            _player.GetComponent<PlayerCombat>().BlasterGet();
            _player.transform.position = position_3.transform.position;
            print("Nivel 3");
            CURRENT_LEVEL = 3;
            gameAudio.PlayBackground(3);
        }
    }
    void NextArea(int nextArea) 
    { 
        if(nextArea == 0)
        {
            CURRENT_LEVEL = 0;
            print("Area Zero");
        }
        else if(nextArea == 1)
        {
            CURRENT_LEVEL = 1;
            print("Area Uno");
        }
        else if (nextArea == 2)
        {
            CURRENT_LEVEL = 2;
            print("Nivel Dos");
        }
        else if (nextArea == 2)
        {
            CURRENT_LEVEL = 3;
            print("Nivel Tres");
        }
    }

}
