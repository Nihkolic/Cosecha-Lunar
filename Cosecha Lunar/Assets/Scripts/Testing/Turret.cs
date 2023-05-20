using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public GameObject bulletPrefab; // The prefab for the bullet
    public Transform bulletSpawnPoint; // The point from which the bullet will be spawned
    public float bulletSpeed = 100f; // The speed of the bullet
    public float shootingRange = 10f; // The range within which the turret can detect the player
    public Transform player; // Reference to the player's transform

    private float nextShootTime = 0f; // The time of the next shot

    // Update is called once per frame
    void Update()
    {
        // Check if the player is within range
        if (player != null && Vector3.Distance(transform.position, player.position) <= shootingRange)
        {
            // Check if enough time has passed since the last shot
            if (Time.time >= nextShootTime)
            {
                Shoot();
                // Set the time of the next shot
                nextShootTime = Time.time + 1f; // Shoot every 1 second
            }
        }
    }

    // Shoot a bullet
    void Shoot()
    {
        // Spawn a bullet from the bullet spawn point
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        // Set the bullet's speed
        bullet.GetComponent<Rigidbody>().velocity = bulletSpawnPoint.forward * bulletSpeed;
        // Destroy the bullet after 5 seconds to prevent cluttering
        //Destroy(bullet, 5f);
    }
}