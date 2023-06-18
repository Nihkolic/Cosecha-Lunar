using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIEnemigo : MonoBehaviour
{
    //[SerializeField] private Renderer meshRenderer;
    //[SerializeField] private Material idleMaterial;
    //[SerializeField] private Material attackMaterial;
    [SerializeField] private LayerMask playerLayerMask;
    [SerializeField] private float distance;
    [SerializeField] private float waitingTime;

    private Transform Target;
    public NavMeshAgent IA;
    public float Velocidad;

    [SerializeField] private GameObject nib_Idlee;
    [SerializeField] private GameObject nib_Attack;
    [SerializeField] private GameObject nib_Chase;

    private void Awake()
    {
        IA = GetComponent<NavMeshAgent>();
        ChangePose(true, false, false);
        Target = GameObject.FindWithTag("Player").transform;
    }
    private void Start()
    {
        IA.speed = Velocidad; 
        // Definición de la velocidad del objeto.

        StartCoroutine(Logic()); 
        // Comienza la corrutina.
    }
    void ChangePose(bool idlee, bool attack, bool chase)
    {
        nib_Idlee.SetActive(idlee);
        nib_Attack.SetActive(attack);
        nib_Chase.SetActive(chase);
    }
    IEnumerator Logic()
    {
        while (true) 
          // Simulación de update.
        {

            //meshRenderer.material = idleMaterial;
            ChangePose(false, false, true);
            // Asigna un material al Mesh Renderer cuando el objeto está en movimiento.

            while (Vector3.Distance(Target.position, transform.position) > distance) 
              // Te acercas al jugador siempre y cuando esté lejos.
            {
                IA.SetDestination(Target.position);
                yield return null;
            }

            //meshRenderer.material = attackMaterial;
            ChangePose(false, true, false);
            // Asigna un material al mesh renderer cuando está en "Ataque"

            Rigidbody rigidbody = gameObject.AddComponent<Rigidbody>(); 
            // Añadir Rigibody al objeto.

            rigidbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ; 
            // Evita que rote el objeto.

            rigidbody.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic; 
            // Evita la detección continua.

            IA.enabled = false; 
            // Es para que se desactive el NavMesh.

            yield return new WaitForSeconds(waitingTime); 
            // Esperar un cierto tiempo antes de continuar

            rigidbody.AddForce((Target.position - transform.position).normalized * 20, ForceMode.Impulse); 
            // Aplicar una fuerza de movimiento hacia el jugador.

            yield return new WaitForSeconds(waitingTime/2); 
            // Esperar un cierto tiempo para continuar.

            IA.enabled = true; 
            // Activación del NavMesh

            Destroy(rigidbody); 
            // Destrucción del Rigibody para que el objeto pueda seguir usando el NavMesh.

            yield return new WaitForEndOfFrame(); 
            // Esperar un frame para seguir ejecutando.
            
        }
       
    }
  
}
