using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class RankingView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI rankingText;

    private RankingController controller;

    void Start()
    {
        controller = GetComponent<RankingController>();
        controller.GetRanking(OnResult);
    }
    void OnResult(RankingArrayData rankingArrayData)
    {
        foreach (RankingData rankingData in rankingArrayData.data)
        {
            rankingText.text += $"{rankingData.NombreDelJugador} -  {rankingData.Puntuacion}\n";
        }
    }
}