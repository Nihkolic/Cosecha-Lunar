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
    private void Start()
    {
        MaxHealth = 200;
        CurrentHealth = MaxHealth;
        playerHUD.UpdateHpBar(CurrentHealth, MaxHealth);
    }
    public void TakeDamage(int amount)
    {
        CurrentHealth -= amount;
        CheckHP();
        playerHUD.UpdateHpBar(CurrentHealth, MaxHealth);
        playerHUD.ScreenEffect(0);
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
}
