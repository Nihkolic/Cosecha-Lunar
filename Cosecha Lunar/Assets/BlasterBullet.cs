using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlasterBullet : MonoBehaviour
{
    [SerializeField] private GameObject blasterBulletDeath;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            GameObject newGameObject = Instantiate(blasterBulletDeath, transform.position, transform.rotation); ;
            Destroy(newGameObject, 0.5f);
        }
        if (other.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            other.transform.gameObject.GetComponent<EnemyHealth2>().DamageEnemy(20f);
            GameObject newGameObject = Instantiate(blasterBulletDeath, transform.position, transform.rotation); ;
            Destroy(newGameObject, 0.5f);
        }

    }
    private void Start()
    {
        
    }
}
