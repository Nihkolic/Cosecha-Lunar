using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    private ScoreSystem scoreSystem;
    [SerializeField] private BossManager bossManager;

    [Header("Materials")]
    [SerializeField] Renderer[] enemyModel;
    [SerializeField] private Material matCurrent;
    [SerializeField] private Material matHurt;

    [Header("Other")]
    private int _currentHealth_1;
    private int _currentHealth_2;
    private int _currentHealth_3;
    private int _currentHealth_4;
    [SerializeField] private int maxHealth;
    [SerializeField] private bool isEnemyDead;
    private bool _isBossResting;

    [SerializeField] private GameObject death_effect;
    
    private void Start()
    {
        isEnemyDead = false;
        _isBossResting = false;

        scoreSystem = FindAnyObjectByType<ScoreSystem>();
        _currentHealth_1 = maxHealth;
        _currentHealth_2 = maxHealth;
        _currentHealth_3 = maxHealth;
        _currentHealth_4 = maxHealth;
    }
    private void Update()
    {
        if (PlayerHealth.PLAYER_IS_DEAD)
        {
            Destroy(transform.parent.gameObject);
        }
    }
    private void OnDestroy()
    {
        //EnemyRoomSpawn.numberOfEnemies--;
        Debug.Log(EnemyRoomSpawn.numberOfEnemies);
    }
    void OnEnable()
    {
        //EnemyRoomSpawn.numberOfEnemies++;

        //GameObject newGameObject = Instantiate(goEnemySpawn, transform.position, transform.rotation);
        //Destroy(newGameObject, 0.5f);

        _currentHealth_1 = maxHealth;
        _currentHealth_2 = maxHealth;
        _currentHealth_3 = maxHealth;
        _currentHealth_4 = maxHealth;
    }
    public void DamageEnemy(int deductHealth)
    {
        if (!isEnemyDead && !_isBossResting)
        {
            TakeDamage(deductHealth, bossManager.bossAI.GetCurrentPhase());
        }
        if (_currentHealth_1 <= 0 && bossManager.bossAI.GetCurrentPhase() == 1)
        {
            bossManager.bossAI.NextNibblerPhase();
        }
        if (_currentHealth_2 <= 0 && bossManager.bossAI.GetCurrentPhase() == 3)
        {
            bossManager.bossAI.NextNibblerPhase();
        }
        if (_currentHealth_3 <= 0 && bossManager.bossAI.GetCurrentPhase() == 5)
        {
            bossManager.bossAI.NextNibblerPhase();
        }
        if (_currentHealth_4 <= 0 && bossManager.bossAI.GetCurrentPhase() == 7)
        {
            BossDeath();
        }

    }
    public void BossRest()
    {
        if (!_isBossResting)
        {
            _isBossResting = true;
        }
    }
    public void BossAwake()
    {
        if (_isBossResting)
        {
            _isBossResting = false;
        }
    }
    void BossDeath()
    {
        if (isEnemyDead == false)
        {
            EnemyScore();
            bossManager.bossArena.OpenTheDoors();
            //GameObject newGameObject = Instantiate(enemyExp, transform.position, transform.rotation);
            //Destroy(newGameObject, 0.5f);

            Destroy(transform.parent.gameObject);
            isEnemyDead = true;
        }

    }
    void EnemyScore()
    {
        scoreSystem.SlaughterAddScore(3);

    }
    void TakeDamage(int deductHealth, int currentPhase)
    {
        switch (currentPhase)
        {
            case 1:
                _currentHealth_1 -= deductHealth;
                bossManager.bossHud.UpdateHpBar(_currentHealth_1, maxHealth, 1);
                break;
            case 3:
                _currentHealth_2 -= deductHealth;
                bossManager.bossHud.UpdateHpBar(_currentHealth_2, maxHealth, 2);
                break;
            case 5:
                _currentHealth_3 -= deductHealth;
                bossManager.bossHud.UpdateHpBar(_currentHealth_3, maxHealth, 3);
                break;
            case 7:
                _currentHealth_4 -= deductHealth;
                bossManager.bossHud.UpdateHpBar(_currentHealth_4, maxHealth, 4);
                break;
        }
        //rendBody.material = matHurt;
        //sfx here
        //rendBody.material.color = Color.red;

        for (int i = 0; i < enemyModel.Length; i++)
        {
            enemyModel[i].material = matHurt;
        }
        Invoke("ToggleNormalColor", 0.2f); //0.25

    }
    void ToggleNormalColor()
    {
        //rendBody.material.color = _normalColor;
        for (int i = 0; i < enemyModel.Length; i++)
        {
            enemyModel[i].material = matCurrent;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Acid"))
        {
            DamageEnemy(300);
        }

    }
    public void ResetHp()
    {/*
        _currentHealth_1 = maxHealth;
        _currentHealth_2 = maxHealth;
        _currentHealth_3 = maxHealth;*/
    }
}
