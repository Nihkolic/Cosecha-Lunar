using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTrigger : MonoBehaviour
{
    bool hasEntered;
    EnemyRoomSpawn enemyRoomSpawn;


    private void Awake()
    {
        hasEntered = false;
        enemyRoomSpawn = GetComponentInParent<EnemyRoomSpawn>();
    }
    public void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            if (!hasEntered)
            {
                enemyRoomSpawn.CloseTheDoors();
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
