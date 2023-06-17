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
            estadoText.text = "Usa [WASD] para moverte";
        }
        if (tutorialNumber == 2)
        {
            estadoText.text = "Presiona [CLIC IZQUIERDO] para atacar";
        }
        if (tutorialNumber == 3)
        {
            estadoText.text = "Presiona [ESPACIO] para saltar";
        }
        if (tutorialNumber == 4)
        {
            estadoText.text = "Presiona [SHIFT] para realizar un dash";
        }
        if (tutorialNumber == 5)
        {
            estadoText.text = "Al atacar enemigos con tu hoz puedes recuperar vida";
        }
        if (tutorialNumber == 6)
        {
            estadoText.text = "Usa la [RUEDA DEL MOUSE] para cambiar de armas";
        }
        if (tutorialNumber == 10)
        {
            tutorialHint.SetActive(false);
        }

    }
}
