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
    [SerializeField] GameObject[] round01;
    [SerializeField] GameObject[] round02;

    bool hasBeenActivated, hasEntered;
    public static int numberOfEnemies;
    bool _isEnemyCheckOn;
    Animator _animatorDoors;

    string animOpen = "Doors_Open";
    string animClose = "Doors_Close";

    [Header("Hallway")]
    [SerializeField] Animator animatorDoor;
    [SerializeField] Animator animatorExit;
    private void Awake()
    {
        if(type == SpawnType.room)
        {
            _animatorDoors = GetComponentInChildren<Animator>();
        }
        else if (type == SpawnType.hallway)
        {

        }
        hasEntered = false;
        hasBeenActivated = false;
        _isEnemyCheckOn = false;
    }
    private void Update()
    {
        if (_isEnemyCheckOn) //check if the enemies are dead
            EnemyCheck();
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
        Invoke("SpawnRound01", 1.0f);
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
            round01[i].SetActive(true);
        }
        _isEnemyCheckOn = true;
        numRounds--;
    }
    void SpawnRound02()
    {
        for (int i = 0; i < round02.Length; i++)
        {
            round02[i].SetActive(true);
        }
        _isEnemyCheckOn = true;
        numRounds=0;
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
            Invoke("SpawnRound02", 1.0f);
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
    void RoomCheck()
    {
        //estadoText.text = "Presiona CLIC DERECHO para atacar";
    }
}
