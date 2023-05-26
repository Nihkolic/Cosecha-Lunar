using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointSystem : MonoBehaviour
{
    [Header("Panels")]
    [SerializeField] private GameObject resultsPanel;
    [SerializeField] private PauseMenu pauseMenu;
    [SerializeField] private TextMeshPro areaText;

    private void Start()
    {
        resultsPanel.SetActive(false);
    }
    public void Continue()
    {
        pauseMenu.ResumeSettings();
        resultsPanel.SetActive(false);
    }
    public void ToResultsMenu()
    {
        pauseMenu.PauseSettings();
        resultsPanel.SetActive(true);
    }
}
