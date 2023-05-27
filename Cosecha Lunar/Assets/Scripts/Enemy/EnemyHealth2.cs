using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth2 : MonoBehaviour
{
    [Header("Materials")]
    [SerializeField] private GameObject model;
    [SerializeField] Renderer[] enemyModel;

    [Header("Materials")]
    [SerializeField] private Renderer rendBody;
    [SerializeField] private Material matCurrent;
    [SerializeField] private Material matHurt;
    private Color _normalColor;

    [Header("Other")]
    [SerializeField] private float enemyHealth = 100f;
    [SerializeField] private bool isEnemyDead;

    [SerializeField] private GameObject goEnemyDeath;
    [SerializeField] private GameObject goEnemySpawn;
    private void Start()
    {
        isEnemyDead = false;
        //_normalColor = model.GetComponent<Renderer>().material.color;
        enemyHealth = 100f;
    }
    private void OnDestroy()
    {
        EnemyRoomSpawn.numberOfEnemies--;
        Debug.Log(EnemyRoomSpawn.numberOfEnemies);
    }
    void OnEnable()
    {
        EnemyRoomSpawn.numberOfEnemies++;

        GameObject newGameObject = Instantiate(goEnemySpawn, transform.position, transform.rotation); ;
        Destroy(newGameObject, 0.5f);
    }
    public void DamageEnemy(float deductHealth)
    {
        if (!isEnemyDead)
        {
            TakeDamage(deductHealth);
        }
        if (enemyHealth <= 0)
            EnemyDead();
    }
    void EnemyDead()
    {
        if (isEnemyDead == false)
        {
            GameObject newGameObject = Instantiate(goEnemyDeath, transform.position, transform.rotation); 
            Destroy(newGameObject, 0.5f);

            isEnemyDead = true;
        }
        Destroy(transform.parent.gameObject);
    }
    IEnumerator Back()
    {
        while (Time.timeScale != 1.0f)
            yield return null;//wait for hit stop to end
        rendBody.material = matCurrent;
    }
    void TakeDamage(float deductHealth)
    {
        enemyHealth -= deductHealth;
        //rendBody.material = matHurt;
        //sfx here
        //rendBody.material.color = Color.red;
        for (int i = 0; i < enemyModel.Length; i++)
        {
            enemyModel[i].material.color = Color.red;
        }
        Invoke("ToggleNormalColor", 0.25f);
    }
    void ToggleNormalColor()
    {
        //rendBody.material.color = _normalColor;
        for (int i = 0; i < enemyModel.Length; i++)
        {
            enemyModel[i].material = matCurrent;
        }
    }

}
