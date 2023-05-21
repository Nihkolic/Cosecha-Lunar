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
            Destroy(gameObject);
        }
        if (GetComponent<Collider>().gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            GetComponent<Collider>().transform.gameObject.GetComponent<EnemyHealth2>().DamageEnemy(20f);
            GameObject newGameObject = Instantiate(blasterBulletDeath, transform.position, transform.rotation); ;
            Destroy(newGameObject, 0.5f);
            Destroy(gameObject);
            Debug.Log("00000");
        }

    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            GameObject newGameObject = Instantiate(blasterBulletDeath, transform.position, transform.rotation); ;
            Destroy(newGameObject, 0.5f);
            Destroy(gameObject);
        }
        if (GetComponent<Collider>().gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            GetComponent<Collider>().transform.gameObject.GetComponent<EnemyHealth2>().DamageEnemy(20f);
            GameObject newGameObject = Instantiate(blasterBulletDeath, transform.position, transform.rotation); ;
            Destroy(newGameObject, 0.5f);
            Destroy(gameObject);
            Debug.Log("222");
        }
        
    }
    private void Start()
    {
        
    }
}
