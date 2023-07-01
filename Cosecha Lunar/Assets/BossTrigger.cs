using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTrigger : MonoBehaviour
{
    bool hasEntered;
    BossArena bossArena;

    private void Awake()
    {
        hasEntered = false;
        bossArena = GetComponentInParent<BossArena>();
    }
    public void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            if (!hasEntered)
            {
                bossArena.CloseTheDoors();
                Debug.Log("Entered");
                hasEntered = true;
            }
            else
            {
                return;
            }
        }
    }
    private void Update()
    {
        if (PlayerHealth.PLAYER_IS_DEAD)
            hasEntered = false;
    }
}
