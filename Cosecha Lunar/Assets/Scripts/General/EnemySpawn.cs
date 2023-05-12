using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    bool hasEntered;
    //public GameObject Enemy1, Enemy2, Enemy3, Enemy4;
    [SerializeField] GameObject[] enemy;
    /*
    bool activated;
    public GameObject Wall, Entrance;
    DestructibleWall destructibleWall;
    public GameObject Number;
    RoomNumber roomNumber;

    private void Awake()
    {
        hasEntered = false;
        activated = false;
        destructibleWall = Wall.GetComponent<DestructibleWall>();
        roomNumber = Number.GetComponent<RoomNumber>();
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            if (!hasEntered)
            {
                hasEntered = true;
                for (int i = 0; i < enemy.Length; i++)
                {
                    enemy[i].SetActive(true);
                    //Instantiate(Enemy1, Enemy2.transform);
                }
                Entrance.SetActive(true);
                RoomNumber.roomNum++;
                roomNumber.NextRoom();
            }
            else
            {
                return;
            }
        }
    }
    private void Update()
    {
        if(EnemyManager.numberOfEnemies == 0 && hasEntered)
        {
            ActivateWall();
            roomNumber.HPtoMax();
        }
    }
    void ActivateWall()
    {
        if (!activated)
        {
            destructibleWall.MakeWallGreen();
            activated = true;
        }
    }*/

}
