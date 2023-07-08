using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Gunmen : MonoBehaviour
{
    NavMeshAgent agent;
    Transform player;
    public GameObject gun;

    //Check for Ground/Obstacles
    public LayerMask whatIsGround, whatIsPlayer;

    //Patroling
    public Vector3 walkPoint;
    public bool walkPointSet;
    public float walkPointRange;

    //Attack Player
    public float timeBetweenAttacks;
    bool alreadyAttacked;

    //States
    public bool isDead;
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    //Special
    public Material green, red, yellow;
    public GameObject projectile;

    [SerializeField] private GameObject gun_idle;
    [SerializeField] private GameObject gun_run;
    Animator _animator;
    private void Awake()
    {
        player = GameObject.FindWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        //ChangePose(true, false);
        _animator = GetComponentInChildren<Animator>();
    }
    void ChangePose(bool idlee, bool run)
    {
        gun_idle.SetActive(idlee);
        gun_run.SetActive(run);
    }
    private void Update()
    {
        if (!isDead)
        {
            //Check if Player in sightrange
            playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);

            //Check if Player in attackrange
            playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);
            /*
            if (!playerInSightRange && !playerInAttackRange) Patroling();
            if (playerInSightRange && !playerInAttackRange) ChasePlayer();
            if (playerInAttackRange && playerInSightRange) AttackPlayer();*/

            //if (!playerInSightRange && !playerInAttackRange) Idle();
            if (playerInSightRange && playerInAttackRange) Idle();
            if (playerInAttackRange && !playerInSightRange) AttackPlayer();
            //if (playerInAttackRange) AttackPlayer();
        }
    }
    void Idle()
    {
        _animator.Play("Idle");
    }
    void RunFromPlayer()
    {
        Vector3 dirToPlayer = transform.position - player.transform.position;
        Vector3 newPos = transform.position + dirToPlayer;

        agent.SetDestination(newPos);

        ChangePose(false, true);
    }
    private void Patroling()
    {
        if (isDead) return;

        if (!walkPointSet) SearchWalkPoint();

        //Calculate direction and walk to Point
        if (walkPointSet)
        {
            agent.SetDestination(walkPoint);

            //Vector3 direction = walkPoint - transform.position;
            //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), 0.15f);
        }

        //Calculates DistanceToWalkPoint
        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        //Walkpoint reached
        if (distanceToWalkPoint.magnitude < 1f)
            walkPointSet = false;

        GetComponent<MeshRenderer>().material = green;
    }
    private void SearchWalkPoint()
    {
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2, whatIsGround))
            walkPointSet = true;
    }
    private void ChasePlayer()
    {
        if (isDead) return;

        agent.SetDestination(player.position);

        GetComponent<MeshRenderer>().material = yellow;
    }
    private void AttackPlayer()
    {
        if (isDead) return;
        _animator.Play("Shoot");

        //Make sure enemy doesn't move
        //agent.SetDestination(transform.position);

        if (!playerInSightRange)
        {
            Vector3 targetPostition = new Vector3(player.position.x,
                                       this.transform.position.y,
                                       player.position.z);
            this.transform.LookAt(targetPostition);
        }
            //transform.LookAt(player);
    }
    public void GunmenShoot()
    {
        if (!alreadyAttacked)
        {
            //Instantiate bullet/projectile
            GameObject currentBullet = Instantiate(projectile, gun.transform.position, Quaternion.identity);
            Destroy(currentBullet, 2f);


            //Add forces to bullet
            //currentBullet.GetComponent<Rigidbody>().AddForce(transform.forward * 50f, ForceMode.Impulse);    

            alreadyAttacked = true;
            Invoke("ResetAttack", timeBetweenAttacks);
        }
    }
    private void ResetAttack()
    {
        if (isDead) return;

        alreadyAttacked = false;
    }/*
    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health < 0)
        {
            isDead = true;
            Invoke("Destroyy", 2.8f);
        }
    }
    private void Destroyy()
    {
        Destroy(gameObject);
    }*/

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }
}
