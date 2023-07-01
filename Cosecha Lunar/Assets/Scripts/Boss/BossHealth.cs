using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    private ScoreSystem scoreSystem;
    
    [Header("Materials")]
    [SerializeField] Renderer[] enemyModel;
    
    [Header("Materials")]
    //[SerializeField] private Renderer rendBody;
    [SerializeField] private Material matCurrent;
    [SerializeField] private Material matHurt;

    [Header("Other")]
    private int _currentHealth_1;
    private int _currentHealth_2;
    private int _currentHealth_3;
    [SerializeField] private int maxHealth;
    [SerializeField] private bool isEnemyDead;
    private bool _isBossResting;
    [SerializeField] private BossHud bossHud;

    [SerializeField] private GameObject meleeDeath;
    [SerializeField] private GameObject bulletDeath;

    //[SerializeField] private GameObject goEnemySpawn;
    [SerializeField] private GameObject healthPrefab;
    BossAI bossAI;
    private void Start()
    {
        isEnemyDead = false;
        _isBossResting = false;
        //_normalColor = model.GetComponent<Renderer>().material.color;
        scoreSystem = FindAnyObjectByType<ScoreSystem>();
        _currentHealth_1 = maxHealth;
        _currentHealth_2 = maxHealth;
        _currentHealth_3 = maxHealth;
        bossAI = GetComponentInParent<BossAI>();
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
    }
    public void DamageEnemy(int deductHealth, bool isWeaponMelee)
    {
        if (!isEnemyDead && !_isBossResting)
        {
            TakeDamage(deductHealth, bossAI.GetCurrentPhase());
        }
        if (_currentHealth_1 <= 0 && bossAI.GetCurrentPhase() == 1)
        {
            bossAI.NextNibblerPhase();
        }
        if (_currentHealth_2 <= 0 && bossAI.GetCurrentPhase() == 3)
        {
            bossAI.NextNibblerPhase();
        }
        if (_currentHealth_3 <= 0 && bossAI.GetCurrentPhase() == 5)
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
                bossHud.UpdateHpBar(_currentHealth_1, maxHealth, 1);
                break;
            case 3:
                _currentHealth_2 -= deductHealth;
                bossHud.UpdateHpBar(_currentHealth_2, maxHealth, 2);
                break;
            case 5:
                _currentHealth_3 -= deductHealth;
                bossHud.UpdateHpBar(_currentHealth_3, maxHealth, 3);
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
            DamageEnemy(300, false);
        }

    }
}
