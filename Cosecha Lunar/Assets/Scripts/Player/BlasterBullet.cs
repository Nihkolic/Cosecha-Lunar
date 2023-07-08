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
            DestroyBullet();
        }
        if (other.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            //GetComponent<Collider>().transform.gameObject.GetComponent<EnemyHealth2>().DamageEnemy(20f);
            other.transform.gameObject.GetComponent<EnemyHealth2>().DamageEnemy(20f, false); //40
            DestroyBullet();
        }
        if (other.gameObject.layer == LayerMask.NameToLayer("Boss"))
        {
            //GetComponent<Collider>().transform.gameObject.GetComponent<EnemyHealth2>().DamageEnemy(20f);
            other.transform.gameObject.GetComponent<BossHealth>().DamageEnemy(15); //10
            DestroyBullet();
        }
    }
    private void OnCollisionEnter(Collision other)
    {
        Bullet(other);
    }
    void Bullet(Collision other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            DestroyBullet();
        }
        if (other.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            //GetComponent<Collider>().transform.gameObject.GetComponent<EnemyHealth2>().DamageEnemy(20f);
            other.transform.gameObject.GetComponent<EnemyHealth2>().DamageEnemy(20f, false);
            DestroyBullet();
        }
        if (other.gameObject.layer == LayerMask.NameToLayer("Boss"))
        {
            //GetComponent<Collider>().transform.gameObject.GetComponent<EnemyHealth2>().DamageEnemy(20f);
            other.transform.gameObject.GetComponent<BossHealth>().DamageEnemy(15);
            DestroyBullet();
        }
    }
    private void DestroyBullet()
    {
        GameObject newGameObject = Instantiate(blasterBulletDeath, transform.position, transform.rotation); 
        Destroy(newGameObject, 0.5f);
        Destroy(gameObject);
    }
}
