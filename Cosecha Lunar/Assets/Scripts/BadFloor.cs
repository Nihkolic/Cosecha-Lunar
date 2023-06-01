using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadFloor : MonoBehaviour
{
    public Transform playerRespawnPosition;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            other.transform.position = playerRespawnPosition.transform.position;
            other.transform.gameObject.GetComponent<PlayerHealth>().TakeDamage(30);
        }

    }
}
