using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstEnemy : MonoBehaviour
{
    [SerializeField] Renderer[] enemyModel;

    [SerializeField] private Material matCurrent;
    [SerializeField] private Material matHurt;

    [Header("Other")]
    [SerializeField] private float enemyHealth = 100f;
    [SerializeField] private bool isEnemyDead;

    [SerializeField] private GameObject deathVFX;
    [SerializeField] private GameObject spawnVFX;
    [SerializeField] private GameObject wall;

    private void OnDestroy()
    {
        wall.SetActive(false);
    }
    void OnEnable()
    {
        GameObject newGameObject = Instantiate(spawnVFX, transform.position, transform.rotation); ;
        Destroy(newGameObject, 0.5f);
    }
    void TakeDamage(float deductHealth)
    {
        enemyHealth -= deductHealth;
        //rendBody.material = matHurt;
        //sfx here
        //rendBody.material.color = Color.red;


        for (int i = 0; i < enemyModel.Length; i++)
        {
            enemyModel[i].material = matHurt;
        }
        Invoke("ToggleNormalColor", 0.2f); //0.25

    }
    void EnemyDead(GameObject enemyExp)
    {
        if (isEnemyDead == false)
        {
            GameObject newGameObject = Instantiate(enemyExp, transform.position, transform.rotation);
            Destroy(newGameObject, 0.5f);

            isEnemyDead = true;
        }
        Destroy(transform.parent.gameObject);
    }
    public void DamageEnemy(float deductHealth, bool isWeaponMelee)
    {
        if (!isEnemyDead)
        {
            TakeDamage(deductHealth);
        }
        if (enemyHealth <= 0)
        {
            EnemyDead(deathVFX);
        }

    }
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.layer == LayerMask.NameToLayer("Player_Weapon"))
        {
            DamageEnemy(20f, true);
            
        }
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
