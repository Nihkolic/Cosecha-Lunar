using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlasterBullet : MonoBehaviour
{
    [SerializeField] private GameObject blasterBulletDeath;
    private void OnTriggerEnter(Collider other)
    {
        GameObject newGameObject = Instantiate(blasterBulletDeath, transform.position, transform.rotation); ;
        Destroy(newGameObject, 0.5f);
        /*
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            Destroy(gameObject);
        }*/

    }
    private void Start()
    {
        
    }
}
