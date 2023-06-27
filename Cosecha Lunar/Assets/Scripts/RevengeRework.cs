using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RevengeRework : MonoBehaviour
{
    public GameObject healthPrefab;
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.layer == LayerMask.NameToLayer("Player_Weapon"))
        {
            //SpawnSphere();

        }
    }
    void SpawnSphere()
    {
        GameObject sphere = Instantiate(healthPrefab, transform.position, Quaternion.identity);
        Rigidbody sphereRigidbody = sphere.GetComponent<Rigidbody>();

        // Apply force to the sphere's rigidbody
        //sphereRigidbody.AddForce(Vector3.up*20f, ForceMode.Impulse);
        //sphereRigidbody.AddRelativeForce(Random.onUnitSphere * 10f);
        /*
        Vector3 force = transform.forward;
        force = new Vector3(force.x, 1, force.z);
        sphereRigidbody.AddForce(force * 100f);*/
    }
}
