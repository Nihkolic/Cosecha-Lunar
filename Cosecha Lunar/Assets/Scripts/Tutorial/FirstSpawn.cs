using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstSpawn : MonoBehaviour
{
    bool hasEntered;
    public GameObject firstEnemy;

    private void Start()
    {
        firstEnemy.SetActive(false);
    }
    public void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            if (!hasEntered)
            {
                firstEnemy.SetActive(true);
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
