using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Leaderboard : MonoBehaviour
{
    [SerializeField] private Transform entryContainer;
    [SerializeField] private Transform entryTemplate;
    private List<Transform> highscoreEntryTransformList;

    private int currentScore;
    private void Awake()
    {
        PlayerScore();
        entryTemplate.gameObject.SetActive(false);

        string jsonString = PlayerPrefs.GetString("highscoreTable");
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);

        if (highscores == null)
        {
            Debug.Log("base data");
            AddHighscoreEntry(500, "CMK");
            AddHighscoreEntry(1000, "JOE");
            AddHighscoreEntry(1500, "DAV");
            AddHighscoreEntry(2000, "CAT");
            AddHighscoreEntry(2500, "MAX");
            // Reload
            jsonString = PlayerPrefs.GetString("highscoreTable");
            highscores = JsonUtility.FromJson<Highscores>(jsonString);
        }

        // Sort
        for (int i = 0; i < highscores.highscoreEntryList.Count; i++)
        {
            for (int j = i + 1; j < highscores.highscoreEntryList.Count; j++)
            {
                if (highscores.highscoreEntryList[j].score > highscores.highscoreEntryList[i].score)
                {
                    // Swap
                    HighscoreEntry tmp = highscores.highscoreEntryList[i];
                    highscores.highscoreEntryList[i] = highscores.highscoreEntryList[j];
                    highscores.highscoreEntryList[j] = tmp;
                }
            }
        }

        highscoreEntryTransformList = new List<Transform>();
        foreach (HighscoreEntry highscoreEntry in highscores.highscoreEntryList)
        {
            CreateHighscoreEntryTransform(highscoreEntry, entryContainer, highscoreEntryTransformList);
        }
    }

    private void CreateHighscoreEntryTransform(HighscoreEntry highscoreEntry, Transform container, List<Transform> transformList)
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
                scoreString = highscoreEntry.score.ToString();
                nameString = highscoreEntry.name;
                break;
            case 1:
                rankString = "<#ABEF09>1°</color>";
                scoreString = $"<#ABEF09>{highscoreEntry.score}</color>";
                nameString = $"<#ABEF09>{highscoreEntry.name}</color>";
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

    private void AddHighscoreEntry(int score, string name)
    {
        // Create HighscoreEntry
        HighscoreEntry highscoreEntry = new HighscoreEntry { score = score, name = name };

        // Load saved scores
        string jsonString = PlayerPrefs.GetString("highscoreTable");
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);

        if (highscores == null)
        {
            // if there s no stored table, initialize
            highscores = new Highscores()
            {
                highscoreEntryList = new List<HighscoreEntry>()
            };
        }

        // new entry to Highscores
        highscores.highscoreEntryList.Add(highscoreEntry);

        // save updated scores
        string json = JsonUtility.ToJson(highscores);
        PlayerPrefs.SetString("highscoreTable", json);
        PlayerPrefs.Save();
    }
    void PlayerScore()
    {
            currentScore = PlayerPrefs.GetInt("Score");

            if (currentScore != 0)
                AddHighscoreEntry(currentScore, "YOU");
      

        
    }
    private class Highscores
    {
        public List<HighscoreEntry> highscoreEntryList;
    }
    //single entry
    [System.Serializable]
    private class HighscoreEntry
    {
        public int score;
        public string name;
    }

}
