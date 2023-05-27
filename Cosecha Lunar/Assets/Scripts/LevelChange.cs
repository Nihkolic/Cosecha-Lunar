using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelChange : MonoBehaviour
{
    [SerializeField] private PointSystem pointSystem;
    public static bool GAME_CANT_BE_PAUSED = false;
    //change later
    [SerializeField] private GameObject endPanel;
    private void Start()
    {
        endPanel.SetActive(false);
    }
    public void ToNextLevel(int currentArea)
    {
        if (currentArea == 0)
        {
            pointSystem.ToResultsMenu(0);
        }
        if (currentArea == 1)
        {
            pointSystem.ToResultsMenu(1);
        }
        if (currentArea == 2)
        {
            pointSystem.ToResultsMenu(2);
            LevelEnd(); //change later
        }
        if (currentArea == 3)
        {
            pointSystem.ToResultsMenu(3);
        }
        GAME_CANT_BE_PAUSED = true;
    }
    public void LevelEnd()
    {
        endPanel.SetActive(true);
    }
}
