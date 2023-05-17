using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DetectionArea : MonoBehaviour
{

    [SerializeField] private LayerMask playerLayerMask;
    [SerializeField] private float distance;

    [SerializeField] private List<Transform> points;
    [SerializeField] private NavMeshAgent IA2;
    [SerializeField] private float distance2;

    [SerializeField] private Renderer meshRenderer;
    [SerializeField] private Material runningMaterial;
    [SerializeField] private Material attackMaterial;

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

        StartCoroutine(RunningLogic()); 
        // Sí te acercas mucho, el objeto se mueve.

    }

    private IEnumerator RunningLogic()
    {
        while (true) 
          // Simulación de update.
        {
            meshRenderer.material = runningMaterial;
            // Asigna un material al Mesh Renderer cuando el objeto está en movimiento.

            while (Vector3.Distance(transform.position, target.transform.position) > distance2)
              // Te acercas al jugador siempre y cuand esté lejos.
            {
                yield return null;
            }
            Vector3 position = points[Random.Range(0, points.Count)].position; 
            // Sirve para que se escoja un punto a donde ir.

            IA2.SetDestination(position); 
            // Le dice al objeto que vaya a ese punto.

            IA2.isStopped = false; 
            // Es para que el objeto se mueva.

            enableShooting = false; 
            // Es para que el objeto deje de disparar.

            while (Vector3.Distance(transform.position, position) > 1) 
              //El objeto está cerca a ese punto.
            {
                yield return null; 
                // Sí no está cerca, continua ejecutandose.

            }
            enableShooting = true; 
            // Sí está cerca, habilita el disparo.

            IA2.isStopped = true; 
            // No moverse.
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, distance); 
        // Detección del jugador para apuntar.

        Gizmos.DrawWireSphere(transform.position, distance2); 
        // Rango de detección del jugador para huir.

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
        if (detected)
        {
            enemy.LookAt(target.transform);
        }
    }

    private void FixedUpdate()
    {
        if (detected)
        {
            meshRenderer.material = attackMaterial;
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
        for (int i = 1; i <= 3; i++) 
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

                yield return new WaitForSeconds(0.25f); 
                // Esperar cierto tiempo para lanzar otra bala.

            }

        }


    }

}
