using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
}

