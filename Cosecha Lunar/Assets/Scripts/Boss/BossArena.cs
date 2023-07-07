using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossArena : MonoBehaviour
{
    [SerializeField] GameObject[] round_1;
    [SerializeField] GameObject[] round_2;

    bool hasBeenActivated, hasEntered;
    //public static int numberOfEnemies;
    bool _isEnemyCheckOn;
    Animator _animatorDoors;

    string animOpen = "Doors_Open";
    string animClose = "Doors_Close";

    [Header("Enemies")]
    [SerializeField] GameObject nibbler;
    [SerializeField] GameObject bulla;
    [SerializeField] private BossManager bossManager;

    public static bool IS_BULLA_ENABLED;

    private void Awake()
    {
        _animatorDoors = GetComponentInChildren<Animator>();

        hasEntered = false;
        hasBeenActivated = false;
        _isEnemyCheckOn = false;

        bulla.SetActive(false);
        IS_BULLA_ENABLED = false;
    }
    private void Update()
    {
        if (_isEnemyCheckOn) //check if the enemies are dead
            EnemyCheck();

        Reset();
    }
    void EnemyCheck()
    {
        if (EnemyRoomSpawn.numberOfEnemies == 0 && hasEntered) //check if all the enemies are dead
        {
            _isEnemyCheckOn = false;
            bossManager.bossAI.NextBossPhase();
            hasEntered = false;
           
        }
    }
    private void Reset()
    {
        if (PlayerHealth.PLAYER_IS_DEAD && (hasBeenActivated || hasEntered))
        {
            hasBeenActivated = false;
            hasEntered = false;
            _isEnemyCheckOn = false;
            DoorsAnimation(animOpen);

            Debug.Log("reset on");
            IS_BULLA_ENABLED = false;
            bulla.SetActive(false);
        }
    }
    public void OpenTheDoors()
    {
        if (!hasBeenActivated)
        {
            DoorsAnimation(animOpen);
            hasBeenActivated = true;
          
        }
        else
        {
            return;
        }
    }
    public void CloseTheDoors() //when you enter - Spawn Bulla
    {
        DoorsAnimation(animClose);
        

        bulla.SetActive(true);
        IS_BULLA_ENABLED = true;
    }
    void DoorsAnimation(string anim)
    {
        _animatorDoors.Play(anim);
    }
    public void SpawnRound_1()
    {
        for (int i = 0; i < round_1.Length; i++)
        {
            Instantiate(nibbler, round_1[i].transform.position, round_1[i].transform.rotation);
        }
        StartCoroutine(DelayMethod());
        Debug.Log("spawn 01");
    }
    public void SpawnRound_2()
    {
        for (int i = 0; i < round_2.Length; i++)
        {
            Instantiate(nibbler, round_2[i].transform.position, round_2[i].transform.rotation);
        }
        StartCoroutine(DelayMethod());
        Debug.Log("spawn 02");
    }
    private IEnumerator DelayMethod()
    {
        Debug.Log("Method execution started.");

        yield return new WaitForSeconds(0.5f); // Delay for 1 second

        Debug.Log("Method execution resumed after 1 second.");
       
        _isEnemyCheckOn = true;
        hasEntered = true;

    }
}