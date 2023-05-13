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

    private void Update()
    {
        Testing();
    }
    private void Start()
    {
        //MaxHealth *= 10;
        CurrentHealth = MaxHealth;
    }
    public void TakeDamage(int amount)
    {
        CurrentHealth -= amount;
        CheckHP();
        playerHUD.UpdateHpBar(CurrentHealth, MaxHealth);
        //playerSfx.PlayHurt();
    }
    public void Heal(int amount)
    {
        CurrentHealth += amount*10;
        if (CurrentHealth > MaxHealth) CurrentHealth = MaxHealth;
        playerHUD.UpdateHpBar(CurrentHealth, MaxHealth);
        //playerSfx.PlayHeal();
    }
    private void CheckHP()
    {
        if (CurrentHealth <= 0)
        {
            SceneManager.LoadScene(2);
        }
    }/*
    public float GetHealthPercent()
    {
        return (float) CurrentHealth / MaxHealth;
    }*/
    private void Testing()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            Heal(1);
        }
        else if (Input.GetKeyDown(KeyCode.P))
        {
            TakeDamage(1);
        }
    }
    public void Revenge(int amount)
    {
        Heal(amount+4);
        Debug.Log("revenge");
    }
}
