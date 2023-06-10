using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossGrenade : MonoBehaviour
{
    public GameObject explosionEffect;
    public float delay = 1f;

    public float explosionForce = 10f;
    public float radius = 10f;

    Rigidbody rig;

    private void Start()
    {
        rig = GetComponent<Rigidbody>();
        Invoke("Explode", delay);
    }

    private void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
        foreach(Collider near in colliders)
        {
            Rigidbody rigb = near.GetComponent<Rigidbody>();

            if (rigb != null)
            {
                rigb.AddExplosionForce(explosionForce, transform.position, radius, 1f, ForceMode.Impulse);
            }
        }
        Instantiate(explosionEffect, transform.position, transform.rotation);
        Destroy(gameObject);
    }

}
