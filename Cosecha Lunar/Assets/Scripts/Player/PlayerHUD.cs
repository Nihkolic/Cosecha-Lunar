using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerHUD : MonoBehaviour
{
    [SerializeField] private Image healthBar;

    [SerializeField] private Animator screenEffect;
    [SerializeField] private TMP_Text textHP;

    private void Start()
    {
        //textHP.text = ("  " + CurrentHealth.ToString());
    }
    public void UpdateHpBar(int currentHealth, int maxHealth)
    {
        healthBar.fillAmount = GetHealthPercent(currentHealth, maxHealth);
        textHP.text = ("HP " + currentHealth.ToString());
    }
    public float GetHealthPercent(int currentHealth, int maxHealth)
    {
        return (float)currentHealth / maxHealth;
    }
    public void ScreenEffect(int state)
    {
        if (state == 0)
        {
            screenEffect.Play("ScreenEffects_Hurt");
        }
        if (state == 1)
        {
            screenEffect.Play("ScreenEffects_Heal");
        }
    }
}
