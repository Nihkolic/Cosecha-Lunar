using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHud : MonoBehaviour
{
    [SerializeField] private Image healthBar_1;
    [SerializeField] private Image healthBar_2;
    [SerializeField] private Image healthBar_3;
    [SerializeField] private Image healthBar_4;

    [SerializeField] private GameObject HealthBar;
    //[SerializeField] private GameObject anim;

    private void Start()
    {
        HealthBar.SetActive(false);
        //anim.SetActive(false);

    }
    private void Update()
    {
        if (BossArena.IS_BULLA_ENABLED)
        {
            HealthBar.SetActive(true);
            //anim.SetActive(true);
        }
        else
        {
            HealthBar.SetActive(false);
        }
    }
    public void UpdateHpBar(int currentHealth, int maxHealth, int healthNum)
    {
        if (healthNum == 1)
            healthBar_1.fillAmount = GetHealthPercent(currentHealth, maxHealth);
        if (healthNum == 2)
            healthBar_2.fillAmount = GetHealthPercent(currentHealth, maxHealth);
        if (healthNum == 3)
            healthBar_3.fillAmount = GetHealthPercent(currentHealth, maxHealth);
        if (healthNum == 4)
            healthBar_4.fillAmount = GetHealthPercent(currentHealth, maxHealth);
    }

    public float GetHealthPercent(int currentHealth, int maxHealth)
    {
        return (float)currentHealth / maxHealth;
    }
    public void ResetHUD()
    {
        UpdateHpBar(1000, 1000, 1);
        HealthBar.SetActive(false);
    }
}
