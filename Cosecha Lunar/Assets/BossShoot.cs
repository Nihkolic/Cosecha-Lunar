using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossShoot : MonoBehaviour
{

    [SerializeField] private LayerMask playerLayerMask;
    [SerializeField] private float distance;

    GameObject target;
    public Transform enemy;
    public GameObject bullet;
    public Transform shootPoint;
    private float originalTime;
    public float shootSpeed = 10f;
    public float timeToShoot = 1.3f;
    private bool enableShooting = true;
    private bool detected;

    void Start()
    {
        target = GameObject.Find("Player");
        // Ubicar al "Jugador"

        originalTime = timeToShoot;


    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, distance);
        // Detección del jugador para apuntar.

    }
    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, target.transform.position) < distance)
        {
            detected = true;
        }
        else
        {
            detected = false;
        }
    }

    private void FixedUpdate()
    {
        if (detected)
        {
            timeToShoot -= Time.deltaTime;

            if (timeToShoot < 0)
            {
                StartCoroutine(ShootPlayer());
                timeToShoot = originalTime;
            }
        }
    }

    private IEnumerator ShootPlayer()
    {
        for (int i = 1; i <= 5; i++)
        // Se va a ejecutar 3 veces.
        {
            if (enableShooting)
            // Ejecución de la rutina.
            {
                GameObject currentBullet = Instantiate(bullet, shootPoint.position, shootPoint.rotation);
                // Creación de bala.

                Rigidbody rig = currentBullet.GetComponent<Rigidbody>();
                // Obtiene el rigibody de la bala.

                rig.AddForce(transform.forward * shootSpeed, ForceMode.VelocityChange);
                // Le da dirección a la bala.

                yield return new WaitForSeconds(0.3f);
                // Esperar cierto tiempo para lanzar otra bala.

            }

        }


    }

}