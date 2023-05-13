using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    bool hasEntered;
    [SerializeField] GameObject[] enemy;
    bool hasBeenActivated;
    public static int numberOfEnemies;
    bool _isEnemyCheckOn;

    Animator animatorDoors;

    public string animOpen;
    public string animClose;

    private void Awake()
    {
        hasEntered = false;
        hasBeenActivated = false;
        animatorDoors = GetComponentInChildren<Animator>();
        _isEnemyCheckOn = false;
    }
    private void Update()
    {
        Debug.Log(EnemySpawn.numberOfEnemies);
        if (_isEnemyCheckOn)
            EnemyCheck();
    }
    public void OpenTheDoors() 
    {
        if (!hasBeenActivated)
        {
            animatorDoors.Play(animOpen);
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
        animatorDoors.Play(animClose);
        hasEntered = true;
    }
    void SpawnEnemies()
    {
        for (int i = 0; i < enemy.Length; i++)
        {
            enemy[i].SetActive(true);
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
}
