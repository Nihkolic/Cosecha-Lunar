using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField] private GameObject blasterBulletDeath;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            other.transform.gameObject.GetComponent<PlayerHealth>().TakeDamage(10);
            DestroyBullet();
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            other.transform.gameObject.GetComponent<PlayerHealth>().TakeDamage(10);
            DestroyBullet();
        }

    }
    void DestroyBullet()
    {
        GameObject newGameObject = Instantiate(blasterBulletDeath, transform.position, transform.rotation); ;
        Destroy(newGameObject, 0.5f);
        Destroy(gameObject);
    }
}
