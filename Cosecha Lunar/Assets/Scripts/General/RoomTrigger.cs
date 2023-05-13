using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTrigger : MonoBehaviour
{
    bool hasEntered;
    EnemySpawn enemySpawn;

    private void Awake()
    {
        hasEntered = false;
        enemySpawn = GetComponentInParent<EnemySpawn>();
    }
    public void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            if (!hasEntered)
            {
                enemySpawn.CloseTheDoors();
                Debug.Log("Entered");
                hasEntered = true;
            }
            else
            {
                return;
            }
        }
    }
}
