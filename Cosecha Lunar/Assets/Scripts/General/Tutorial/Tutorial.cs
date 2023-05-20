using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Tutorial : MonoBehaviour
{
    [SerializeField] private TMP_Text estadoText;
    [SerializeField] private GameObject tutorialHint;
    private void Start()
    {
        tutorialHint.SetActive(false);
    }
    public void ShowHint(int tutorialNumber)
    {
        if (tutorialNumber == 1)
        {
            tutorialHint.SetActive(true);
            estadoText.text = "Presiona CLIC DERECHO para atacar";
        }
        if (tutorialNumber == 2)
        {
            estadoText.text = "Presiona ESPACIO para saltar";
        }
        if (tutorialNumber == 3)
        {
            estadoText.text = "Presiona SHIFT para usar el dash";
        }
        if (tutorialNumber == 4)
        {
            tutorialHint.SetActive(false);
        }

    }
}
