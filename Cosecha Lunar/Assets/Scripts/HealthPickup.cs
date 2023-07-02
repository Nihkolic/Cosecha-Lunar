using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    public GameObject healVFX;
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            collider.transform.gameObject.GetComponent<PlayerHealth>().Heal(20);

            GameObject newGameObject = Instantiate(healVFX, transform.position, transform.rotation);
            Destroy(newGameObject, 0.5f);
            Destroy(transform.parent.gameObject);
        }
    }
}
