using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelChange : MonoBehaviour
{
    [SerializeField] private PointSystem pointSystem;
    public static bool GAME_CANT_BE_PAUSED = false;

    private GameObject _player;
    [SerializeField] private Transform position_0;
    [SerializeField] private Transform position_1;
    [SerializeField] private Transform position_2;
    [SerializeField] private Transform position_3;

    [SerializeField] private GameObject endPanel;     //change later
    private void Start()
    {
        endPanel.SetActive(false);
        _player = GameObject.FindWithTag("Player");
    }
    private void Update()
    {
        LevelChangeDebug();
    }
    public void ToNextLevel(int currentArea)
    {
        if (currentArea == 0)
        {
            pointSystem.ToResultsMenu(0);
            _player.transform.position = position_1.transform.position;

            Debug.Log(0 + " End");
        }
        if (currentArea == 1)
        {
            pointSystem.ToResultsMenu(1);
            _player.transform.position = position_2.transform.position;

            Debug.Log(1 + " End");
        }
        if (currentArea == 2)
        {
            pointSystem.ToResultsMenu(2);
            _player.transform.position = position_3.transform.position;

            Debug.Log(2 + " End");
        }
        if (currentArea == 3)
        {
            pointSystem.ToResultsMenu(3);
            LevelEnd();

            Debug.Log(3 + " End");
        }
        GAME_CANT_BE_PAUSED = true;
    }
    public void LevelEnd()
    {
        endPanel.SetActive(true);
    }
    private void LevelChangeDebug()
    {
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            _player.GetComponent<PlayerCombat>().BlasterRevert();
            _player.transform.position = position_0.transform.position;
            print("Nivel 0");
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            _player.GetComponent<PlayerCombat>().BlasterRevert();
            _player.transform.position = position_1.transform.position;
            print("Nivel 1");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            _player.GetComponent<PlayerCombat>().BlasterGet();
            _player.transform.position = position_2.transform.position;
            print("Nivel 2");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            _player.GetComponent<PlayerCombat>().BlasterGet();
            _player.transform.position = position_3.transform.position;
            print("Nivel 3");
        }
    }
}
