using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreSystem : MonoBehaviour
{
    private int skillPoints;
    private int skillFull;

    private int slaugtherPoints;

    [SerializeField] private TMP_Text slaugtherText;
    [SerializeField] private TMP_Text skillText;

    void Start()
    {
        ResetScore();
    }
    public void ResetScore()
    {
        skillFull = 20000;
        skillPoints = skillFull;

        slaugtherPoints = 0;
    }
    public void SkillReduceScore(int damageTaken)
    {
        skillPoints -= (damageTaken*20);
       
        skillText.text = "Skill: " + skillPoints.ToString();
    }
    public int SkillGetScore()
    {
        return skillPoints;
    }
    public void SlaughterAddScore(int enemyType) // Call this method when the player kills an enemy
    {
        switch (enemyType)
        {
            case 3: //Bulla
                slaugtherPoints += 7500;
                break;
            case 2: //Gunmen
                slaugtherPoints += 450;
                break;
            case 1: //Nibblers
                slaugtherPoints += 200;
                break;
            default:
                print("ah");
                break;
        }

        slaugtherText.text = "Slaughter: " + slaugtherPoints.ToString();
    }
    public int SlaughterGetScore()
    {
        return slaugtherPoints;
    }
    public int GetTotalScore()
    {
        return SlaughterGetScore() + SkillGetScore();
    }
}
