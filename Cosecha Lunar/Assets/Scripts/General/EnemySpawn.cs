using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject enemy;
    void Start()
    {
        Invoke("SpawnTheEnemy", 2);
    }
    void SpawnTheEnemy()
    {
        Instantiate(enemy, gameObject.transform.position, gameObject.transform.rotation);
        Destroy(gameObject, 0.1f);
    }
}
