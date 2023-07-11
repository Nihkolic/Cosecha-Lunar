using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewLevelChange : MonoBehaviour
{
    public static bool GAME_CANT_BE_PAUSED = false;

    [SerializeField] private GameObject _player;
    [SerializeField] private Transform position_0;
    [SerializeField] private Transform position_1;
    [SerializeField] private Transform position_2;
    [SerializeField] private Transform position_3;

    public static int CURRENT_LEVEL;

    [SerializeField] private GameObject deathPanel;
    [SerializeField] private PauseMenu pauseMenu;
    private void Awake()
    {
        //_player = GameObject.FindWithTag("Player");
        _player.transform.position = position_0.transform.position;

        CURRENT_LEVEL = 0;

        deathPanel.SetActive(false);
    }
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
