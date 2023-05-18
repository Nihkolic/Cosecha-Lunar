using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Tutorial : MonoBehaviour
{
    [SerializeField] private TMP_Text estadoText;
    [SerializeField] private GameObject tutorialHint;
    public void ShowHint(int tutorialNumber)
    {
        if (tutorialNumber == 1)
        {
            estadoText.text = "01";
        }
        if (tutorialNumber == 2)
        {
            estadoText.text = "02";
        }
        if (tutorialNumber == 3)
        {
            estadoText.text = "03";
        }
        if (tutorialNumber == 4)
        {
            tutorialHint.SetActive(false);
        }
    }
}
