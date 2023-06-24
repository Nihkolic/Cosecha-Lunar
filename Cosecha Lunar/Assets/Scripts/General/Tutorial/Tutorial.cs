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
            estadoText.text = "Usa <#FFFF00>[W-A-S-D]</color> para <#00FFFF>MOVERTE</color>";
        }
        if (tutorialNumber == 2)
        {
            estadoText.text = "Presiona <#FFFF00>[CLIC IZQUIERDO]</color> para <#00FFFF>ATACAR</color>";
        }
        if (tutorialNumber == 3)
        {
            estadoText.text = "Presiona <#FFFF00>[ESPACIO]</color> para <#00FFFF>SALTAR</color>";
        }
        if (tutorialNumber == 4)
        {
            estadoText.text = "Presiona <#FFFF00>[SHIFT]</color> para realizar un <#00FFFF>DASH</color>";
        }
        if (tutorialNumber == 5)
        {
            estadoText.text = "Al atacar enemigos con tu <#FFFF00>HOZ</color> puedes recuperar <#FF5853>VIDA</color>";
        }
        if (tutorialNumber == 6)
        {
            estadoText.text = "Usa la <#FFFF00>[RUEDA DEL MOUSE]</color> para <#00FFFF>CAMBIAR DE ARMA</color>";
        }
        if (tutorialNumber == 10)
        {
            tutorialHint.SetActive(false);
        }

    }
}
