using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyHallwaySpawn : MonoBehaviour
{
    [SerializeField] GameObject[] round01;
    [SerializeField] GameObject[] round02;
    bool hasBeenActivated, hasEntered;
    public static int numberOfEnemies;
    bool _isEnemyCheckOn;

    [SerializeField] Animator animatorDoor;
    [SerializeField] Animator animatorExit;

    string animOpen = "Doors_Open";
    string animClose = "Doors_Close";

    private void Awake()
    {
        hasEntered = false;
        hasBeenActivated = false;
        //animatorDoors = GetComponentInChildren<Animator>();
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
            animatorDoor.Play(animOpen);
            animatorExit.Play(animOpen);
            hasBeenActivated = true;
        }
        else
        {
            return;
        }
    }
    public void CloseTheDoors() //when you enter
    {
        Invoke("SpawnEnemies", 1.0f);
        animatorDoor.Play(animClose);
        animatorExit.Play(animOpen);
        hasEntered = true;
    }
    void SpawnEnemies()
    {
        for (int i = 0; i < round01.Length; i++)
        {
            round01[i].SetActive(true);
        }
        _isEnemyCheckOn = true;
    }
    void EnemyCheck()
    {
        if (numberOfEnemies == 0 && hasEntered) //check if all the enemies are dead
        {
            OpenTheDoors();
        }
    }
    void RoomCheck()
    {
        //estadoText.text = "Presiona CLIC DERECHO para atacar";
    }
}
