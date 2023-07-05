using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class RankingView : MonoBehaviour
{
    private RankingController controller;

    [SerializeField] private Transform entryContainer;
    [SerializeField] private Transform entryTemplate;
    private List<Transform> highscoreEntryTransformList;

    void Start()
    {
        controller = GetComponent<RankingController>();
        controller.GetRanking(OnResult);
        entryTemplate.gameObject.SetActive(false);
    }
    void OnResult(RankingArrayData rankingArrayData)
    {
        highscoreEntryTransformList = new List<Transform>();
        foreach (RankingData rankingData in rankingArrayData.data)
        {
            //rankingText.text += $"{rankingData.NombreDelJugador} -  {rankingData.Puntuacion}\n";
            CreateHighscoreEntryTransform(rankingData.Puntuacion, rankingData.NombreDelJugador, entryContainer, highscoreEntryTransformList);
        }
    }
    private void CreateHighscoreEntryTransform(int score, string name, Transform container, List<Transform> transformList)
    {
        float templateHeight = 65f;
        Transform entryTransform = Instantiate(entryTemplate, container);
        RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
        entryRectTransform.anchoredPosition = new Vector2(0, -templateHeight * transformList.Count);
        entryTransform.gameObject.SetActive(true);

        int rank = transformList.Count + 1;
        string rankString;
        string scoreString;
        string nameString;
        switch (rank) 
        {
            default:
                rankString = rank + "°";
                scoreString = score.ToString();
                nameString = name;
                break;
            case 1: 
                rankString = "<#ABEF09>1°</color>"; 
                scoreString = $"<#ABEF09>{score}</color>";
                nameString = $"<#ABEF09>{name}</color>";
                break;/*

            case 2: 
                rankString = "<#00FFFF>2°</color>";
                scoreString = "2";
                break;

            case 3: 
                rankString = "<#FFFF00>3°</color>";
                scoreString = "2";
                break;*/
        }
        entryTransform.Find("Rank_Text").GetComponent<TMP_Text>().text = rankString;
        entryTransform.Find("Score_Text").GetComponent<TMP_Text>().text = scoreString;
        entryTransform.Find("Name_Text").GetComponent<TMP_Text>().text = nameString;

        transformList.Add(entryTransform);
    }
}
