using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreSystem : MonoBehaviour
{
    public int scorePerKill = 100;   //points awarded for each kill
    public int scorePerHeadshot = 50;  

    [SerializeField] private TMP_Text scoreText;  

    private int score = 0;   

    void Start()
    {

    }
    void Update()
    {

    }

    public void AddScore(bool headshot) // Call this method when the player kills an enemy
    {
        // Award points for the kill
        int points = scorePerKill;

        // Add extra points for headshots
        if (headshot)
        {
            points += scorePerHeadshot;
        }

        // Add the points to the player's score
        score += points;

        // Update the score text display
        scoreText.text = "SCORE: " + score.ToString();
    }
    // Call this method when the game ends
    private void EndGame()
    {
        // Do something to end the game here
    }
}
