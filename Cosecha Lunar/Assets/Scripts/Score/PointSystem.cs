using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointSystem : MonoBehaviour
{
    [Header("Panels")]
    [SerializeField] private GameObject resultsPanel;
    [SerializeField] private PauseMenu pauseMenu;
    [SerializeField] private TMP_Text areaText;

    [Header("Audio")]
    [SerializeField] private GameAudio gameAudio;

    int currentLevel;

    private void Start()
    {
        resultsPanel.SetActive(false);
    }
    public void Continue() //button
    {
        pauseMenu.ResumeSettings();
        resultsPanel.SetActive(false);
        LevelChange.GAME_CANT_BE_PAUSED = false;
        gameAudio.PlayResults();

        if (currentLevel == 0)
        {

        }
        if (currentLevel == 1)
        {
            gameAudio.PlayBackground(2);
        }
        if (currentLevel == 2)
        {
            //keep just some ambient music until we meet the boss
        }
        if (currentLevel == 3)
        {

        }
    }
    public void ToResultsMenu(int nivel)
    {
        pauseMenu.PauseSettings();
        resultsPanel.SetActive(true);
        gameAudio.PlayResults();

        if (nivel == 0)
        {
            areaText.text = ("Area: ZERO");
            currentLevel = 0;
        }
        if (nivel == 1)
        {
            areaText.text = ("Area: UNO");
            currentLevel = 1;
        }
        if (nivel == 2)
        {
            areaText.text = ("Area: DOS");
            currentLevel = 2;
        }
        if (nivel == 3)
        {
            areaText.text = ("Area: TRES");
            currentLevel = 3;
        }
    }
}
