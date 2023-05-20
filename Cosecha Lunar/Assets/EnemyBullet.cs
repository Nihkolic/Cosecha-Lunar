using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField] private GameObject blasterBulletDeath;
    public LayerMask layerMask;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            //GameObject newGameObject = Instantiate(blasterBulletDeath, transform.position, transform.rotation); ;
            //Destroy(newGameObject, 0.5f);
            other.transform.gameObject.GetComponent<PlayerHealth>().TakeDamage(10);
            Destroy(gameObject);
            Debug.Log("00000");
        }
        Debug.Log("11111");
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            //GameObject newGameObject = Instantiate(blasterBulletDeath, transform.position, transform.rotation); ;
            //Destroy(newGameObject, 0.5f);
            other.transform.gameObject.GetComponent<PlayerHealth>().TakeDamage(10);
            Destroy(gameObject);
            Debug.Log("00000");
        }
        Debug.Log("11111");
    }
}
