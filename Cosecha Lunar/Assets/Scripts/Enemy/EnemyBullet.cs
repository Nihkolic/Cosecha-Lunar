using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField] private GameObject blasterBulletDeath;
    Transform player;
    private Vector3 targetDirection;
    private void Start()
    {
        // Find the player's transform
        player = GameObject.FindGameObjectWithTag("Player").transform;

        // Calculate the direction towards the player
        targetDirection = (player.position - transform.position).normalized;

        // Move the bullet in the calculated direction
        GetComponent<Rigidbody>().velocity = targetDirection * Random.Range(45f, 65f);
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            other.transform.gameObject.GetComponent<PlayerHealth>().TakeDamage(10);
            DestroyBullet();
        }
        if (other.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
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
        if (other.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
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
