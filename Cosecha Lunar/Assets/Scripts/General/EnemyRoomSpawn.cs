using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyRoomSpawn : MonoBehaviour
{
    [Header("General")]
    [SerializeField] private SpawnType type;
    public enum SpawnType
    {
        room,
        hallway
    }
    [Range(1, 2)] [SerializeField] int numRounds = 1;
    int _totalRounds;
    [SerializeField] GameObject[] round01;
    [SerializeField] GameObject[] round02;
    [SerializeField] GameObject[] gunmenPosition;

    bool hasBeenActivated, hasEntered;
    public static int numberOfEnemies;
    bool _isEnemyCheckOn;
    Animator _animatorDoors;

    string animOpen = "Doors_Open";
    string animClose = "Doors_Close";

    [Header("Hallway")]
    [SerializeField] Animator animatorDoor;
    [SerializeField] Animator animatorExit;

    [Header("Enemies")]
    [SerializeField] GameObject nibbler;
    [SerializeField] GameObject gunmen;
    public bool areGunmenHere;
    private void Awake()
    {
        if (type == SpawnType.room)
        {
            _animatorDoors = GetComponentInChildren<Animator>();
        }
        else if (type == SpawnType.hallway)
        {

        }
        hasEntered = false;
        hasBeenActivated = false;
        _isEnemyCheckOn = false;

        _totalRounds = numRounds;
    }
    private void Update()
    {
        if (_isEnemyCheckOn) //check if the enemies are dead
            EnemyCheck();

        Reset();
    }
    private void Reset()
    {
        if (PlayerHealth.PLAYER_IS_DEAD &&(hasBeenActivated || hasEntered))
        {
            hasBeenActivated = false;
            hasEntered = false;
            _isEnemyCheckOn = false;
            DoorsAnimation(animOpen);
            numRounds = _totalRounds;

            Debug.Log("reset on");
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
    public void CloseTheDoors() //when you enter
    {
        //Invoke("SpawnRound01", 1.0f);
        SpawnRound01();
        if (areGunmenHere)
        {
            //Invoke("SpawnRound01_Gunmen", 1.0f);
            SpawnRound01_Gunmen();
        }
        DoorsAnimation(animClose);
        hasEntered = true;
    }
    void DoorsAnimation(string anim)
    {
        if (type == SpawnType.room)
        {
            _animatorDoors.Play(anim);
        }
        else if (type == SpawnType.hallway)
        {
            animatorDoor.Play(anim);
            animatorExit.Play(anim);
        }
    }
    void SpawnRound01()
    {
        for (int i = 0; i < round01.Length; i++)
        {
            Instantiate(nibbler, round01[i].transform.position, round01[i].transform.rotation);
        }
        _isEnemyCheckOn = true;
        numRounds--;

        Debug.Log("spawn 01");
    }
    void SpawnRound01_Gunmen()
    {
        for (int i = 0; i < gunmenPosition.Length; i++)
        {
            Instantiate(gunmen, gunmenPosition[i].transform.position, gunmenPosition[i].transform.rotation);
        }
    }
    void SpawnRound02()
    {
        for (int i = 0; i < round02.Length; i++)
        {
            //round02[i].SetActive(true);
            Instantiate(nibbler, round02[i].transform.position, round02[i].transform.rotation);
        }
        _isEnemyCheckOn = true;
        numRounds = 0;
    }
    void EnemyCheck()
    {
        if (numberOfEnemies == 0 && hasEntered) //check if all the enemies are dead
        {
            NewRound();
        }
    }
    void NewRound()
    {
        if (numRounds > 0)
        {
            //Invoke("SpawnRound02", 1.0f);
            SpawnRound02();
        }
        else if(numRounds == 0)
        {
            OpenTheDoors();
            if (type == SpawnType.hallway)
            {
                animatorDoor.Play(animClose);
            }
        }
    }
    
}
