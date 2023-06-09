using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int CurrentHealth;
    [SerializeField] private int MaxHealth = 20;
    [SerializeField] private PlayerHUD playerHUD;
    //public PlayerSfx playerSfx;

    [SerializeField] private LevelChange levelChange;
    [SerializeField] private ScoreSystem scoreSystem;

    public static bool PLAYER_IS_DEAD;
    private void Update()
    {
        HintCheck();
    }
    private void Start()
    {
        MaxHealth = 200;
        CurrentHealth = MaxHealth - 50;
        playerHUD.UpdateHpBar(CurrentHealth, MaxHealth);
        PLAYER_IS_DEAD = false;
    }
    public void TakeDamage(int amount)
    {
        CurrentHealth -= amount;
        CheckHP();
        playerHUD.UpdateHpBar(CurrentHealth, MaxHealth);
        playerHUD.ScreenEffect(0);
        scoreSystem.SkillReduceScore(amount);
        //playerSfx.PlayHurt();
    }
    public void Heal(int amount)
    {
        CurrentHealth += amount;
        if (CurrentHealth > MaxHealth) CurrentHealth = MaxHealth;
        playerHUD.UpdateHpBar(CurrentHealth, MaxHealth);
        playerHUD.ScreenEffect(1);
        //playerSfx.PlayHeal();
    }
    private void CheckHP()
    {
        if (CurrentHealth <= 0)
        {
            Death();
        }
    }/*
    public float GetHealthPercent()
    {
        return (float) CurrentHealth / MaxHealth;
    }*/
    public void Revenge(int amount)
    {
        Heal(amount);
        Debug.Log("revenge");
    }
    void Death()
    {
        levelChange.PlayerDeath();
        PLAYER_IS_DEAD = true;

        CurrentHealth = MaxHealth;
        playerHUD.UpdateHpBar(CurrentHealth, MaxHealth);
    }
    void Respawn()
    {
        PLAYER_IS_DEAD = false;
    }
    void HintCheck()
    {
        // Calculate the health percentage
        float healthPercentage = (float)CurrentHealth / MaxHealth;

        // Check if health is below 10%
        if (healthPercentage < 0.55f)
        {
            playerHUD.ShowHealthMessage();   
        }
    }

}
