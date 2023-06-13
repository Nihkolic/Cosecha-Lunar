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

    private void Start()
    {
        resultsPanel.SetActive(false);
    }
    public void Continue() //button
    {
        pauseMenu.ResumeSettings();
        resultsPanel.SetActive(false);
        LevelChange.GAME_CANT_BE_PAUSED = false;
    }
    public void ToResultsMenu(int nivel)
    {
        pauseMenu.PauseSettings();
        resultsPanel.SetActive(true);

        if(nivel == 0)
        {
            areaText.text = ("Area: ZERO");
        }
        if (nivel == 1)
        {
            areaText.text = ("Area: UNO");
        }
        if (nivel == 2)
        {
            areaText.text = ("Area: DOS");
        }
        if (nivel == 3)
        {
            areaText.text = ("Area: TRES");
        }
    }
}
