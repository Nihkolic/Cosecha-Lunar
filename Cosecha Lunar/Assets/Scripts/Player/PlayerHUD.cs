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

    public GameObject healthMessageText;
    private bool messageShown = false;
    private void Start()
    {
        //textHP.text = ("  " + CurrentHealth.ToString());
        healthMessageText.SetActive(false);
        messageShown = false;
    }
    public void UpdateHpBar(int currentHealth, int maxHealth)
    {
        healthBar.fillAmount = GetHealthPercent(currentHealth, maxHealth);
        textHP.text = ("" + currentHealth.ToString());
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
    public void ShowHealthMessage()
    {
        if (!messageShown)
        {
            healthMessageText.SetActive(true);
            messageShown = true;

            StartCoroutine(HideMessageAfterDelay(4f));
        }
    }

    public void HideHealthMessage()
    {
        if (messageShown)
        {
            healthMessageText.SetActive(false);
            messageShown = false;
        }
    }
    private IEnumerator HideMessageAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        // Hide the message
        HideHealthMessage();
    }
}
