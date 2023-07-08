using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossAI : MonoBehaviour
{
    public State currentState = State.Spawn;
    public enum State { Follow, Spawn, Attack, Rest, Idle, Awake }

    BossHealth bossHealth;
    int currentPhase;
    public GameObject barrier;
    public BossArena bossArena;

    private void Awake()
    {
        bossHealth = GetComponentInChildren<BossHealth>();
        currentPhase = 1;
        barrier.SetActive(false);

        player = GameObject.FindWithTag("Player").transform;
        //agent = GetComponent<NavMeshAgent>();

        _animator = GetComponentInChildren<Animator>();
    }
    private void OnEnable()
    {
        currentState = State.Spawn;
    }
    void Update()
    {
        States();
        PhaseChange();

        print("PHASE " + currentPhase);
        Attack();
    }
    void PhaseChange()
    {
        switch (currentPhase)
        {
            case 1:
                
                break;
            case 2:
                currentState = State.Rest;
                break;
            case 3:
                currentState = State.Awake;
                break;
            case 4:
                currentState = State.Rest;
                break;
            case 5:
                currentState = State.Awake;
                break;
        }
    }
    public void NextBossPhase()
    {
        currentPhase++;

    }
    public void NextNibblerPhase()
    {
        currentPhase++;

        if(currentPhase==2)
            bossArena.SpawnRound_1();
        else if(currentPhase==4)
            bossArena.SpawnRound_2();

    }
    void States()
    {
        switch (currentState)
        {
            case State.Idle:
                Debug.Log("idle");
               
                break;
            case State.Spawn:
                Debug.Log("Spawning");

                break;
            case State.Follow:
                Debug.Log("Follow");
                break;
            case State.Attack:
                Debug.Log("Attacking!");
               
                break;
            case State.Rest:
                Debug.Log("AAAHHH");
                bossHealth.BossRest();
                barrier.SetActive(true);
                
                break;
            case State.Awake:
                Debug.Log("REAL");
                bossHealth.BossAwake();
                barrier.SetActive(false);
               
                break;
        }
    }
    public int GetCurrentPhase()
    {
        return currentPhase;
    }

    NavMeshAgent agent;
    Transform player;
    public GameObject gun;
    public GameObject gun2;
    public GameObject gun3;

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
    public GameObject projectile;

    [SerializeField] private GameObject gun_idle;
    [SerializeField] private GameObject gun_run;
    Animator _animator;
    void ChangePose(bool idlee, bool run)
    {
        gun_idle.SetActive(idlee);
        gun_run.SetActive(run);
    }
    private void Attack()
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

        
    }
    private void AttackPlayer()
    {
        if (currentPhase == 2 || currentPhase == 4) return;
        _animator.Play("Shoot");
        GunmenShoot();
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

            GameObject currentBullet2 = Instantiate(projectile, gun2.transform.position, Quaternion.identity);
            Destroy(currentBullet, 2f);

            GameObject currentBullet3 = Instantiate(projectile, gun3.transform.position, Quaternion.identity);
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
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }
}

