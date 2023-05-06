using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHUD : MonoBehaviour
{
    [SerializeField] private Image healthBar;

    [SerializeField] private Animator screenEffect;
    [SerializeField] private Text textHP;

    private void Start()
    {
        //textHP.text = ("  " + CurrentHealth.ToString());
      
    }
    public void UpdateHpBar(int currentHealth, int maxHealth)
    {
        healthBar.fillAmount = GetHealthPercent(currentHealth, maxHealth);
        //textHP.text = ("  " + CurrentHealth.ToString());
    }
    public float GetHealthPercent(int currentHealth, int maxHealth)
    {
        return (float)currentHealth / maxHealth;
    }
    public void TakeDamage(int amount)
    {
        screenEffect.Play("HurtScreen");

        screenEffect.Play("HealScreen");
    }
}
