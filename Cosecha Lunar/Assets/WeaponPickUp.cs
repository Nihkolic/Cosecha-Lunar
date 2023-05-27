using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickUp : MonoBehaviour
{
    bool hasEntered;
    public void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            if (!hasEntered)
            {
                collider.transform.gameObject.GetComponent<PlayerCombat>().BlasterGet();
                Debug.Log("Blaster Get");
                hasEntered = true;
                Destroy(transform.parent.gameObject);
            }
            else
            {
                return;
            }
        }
    }
}
