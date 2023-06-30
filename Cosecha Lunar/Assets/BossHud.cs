using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHud : MonoBehaviour
{
    [SerializeField] private Image healthBar;

    private void Start()
    {

    }
    public void UpdateHpBar(int currentHealth, int maxHealth)
    {
        healthBar.fillAmount = GetHealthPercent(currentHealth, maxHealth);
    }
    public float GetHealthPercent(int currentHealth, int maxHealth)
    {
        return (float)currentHealth / maxHealth;
    }
}
