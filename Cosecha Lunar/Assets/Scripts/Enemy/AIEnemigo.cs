using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIEnemigo : MonoBehaviour
{
    public Transform Target;
    public float Velocidad;
    public NavMeshAgent IA;
    [SerializeField] private float distance;
    [SerializeField] private float waitingTime;
    [SerializeField] private LayerMask playerLayerMask;
    [SerializeField] private Renderer meshRenderer;
    [SerializeField] private Material idleMaterial;
    [SerializeField] private Material attackMaterial;

    private void Start()
    {
        IA.speed = Velocidad;
        StartCoroutine(Logic());
    }
    void Update()
    {        
        
    }

    IEnumerator Logic()
    {
        while (true)
        {
            RaycastHit hit;
            meshRenderer.material = idleMaterial;

            while (Vector3.Distance(Target.position, transform.position) > distance)
            {
                IA.SetDestination(Target.position);
                yield return null;

            }

            meshRenderer.material = attackMaterial;
            Physics.Raycast(transform.position, Target.position - transform.position, out hit, Vector3.Distance(transform.position, Target.position), playerLayerMask);
            Debug.Log("aqui");
            IA.enabled = false;
            Rigidbody rigidbody =  gameObject.AddComponent<Rigidbody>();
            rigidbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
            rigidbody.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
            yield return new WaitForSeconds(waitingTime);
            rigidbody.AddForce((Target.position - transform.position).normalized * 20, ForceMode.Impulse);
            yield return new WaitForSeconds(waitingTime/2);
            Destroy(rigidbody);
            IA.enabled = true;
            yield return new WaitForEndOfFrame();
            
        }
       
    }
}
