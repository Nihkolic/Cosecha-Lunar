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
    private int _currentHealth;
    [SerializeField] private int maxHealth;
    [SerializeField] private bool isEnemyDead;
    private bool _isBossResting;
    [SerializeField] private BossHud bossHud;

    [SerializeField] private GameObject meleeDeath;
    [SerializeField] private GameObject bulletDeath;

    [SerializeField] private GameObject goEnemySpawn;
    [SerializeField] private GameObject healthPrefab;
    private void Start()
    {
        isEnemyDead = false;
        _isBossResting = false;
        //_normalColor = model.GetComponent<Renderer>().material.color;
        scoreSystem = FindAnyObjectByType<ScoreSystem>();
        _currentHealth = maxHealth;
    }
    private void Update()
    {
        if (PlayerHealth.PLAYER_IS_DEAD)
        {
            Destroy(transform.parent.gameObject);
        }
        print("BULLA: "+ _currentHealth);
    }
    private void OnDestroy()
    {
        //EnemyRoomSpawn.numberOfEnemies--;
        Debug.Log(EnemyRoomSpawn.numberOfEnemies);
    }
    void OnEnable()
    {
        //EnemyRoomSpawn.numberOfEnemies++;

        GameObject newGameObject = Instantiate(goEnemySpawn, transform.position, transform.rotation); ;
        Destroy(newGameObject, 0.5f);
    }
    public void DamageEnemy(int deductHealth, bool isWeaponMelee)
    {
        if (!isEnemyDead && !_isBossResting)
        {
            TakeDamage(deductHealth);
        }
        if (_currentHealth <= 0)
        {
            BossDeath();
        }

    }
    void BossRest()
    {
        if (!_isBossResting)
        {
            _isBossResting = true;
        }
    }
    void BossAwake()
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
    void TakeDamage(int deductHealth)
    {
        _currentHealth -= deductHealth;
        //rendBody.material = matHurt;
        //sfx here
        //rendBody.material.color = Color.red;

        bossHud.UpdateHpBar(_currentHealth, maxHealth);

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
