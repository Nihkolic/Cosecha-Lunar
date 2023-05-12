using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    bool hasEntered;
    //public GameObject Enemy1, Enemy2, Enemy3, Enemy4;
    [SerializeField] GameObject[] enemy;
    
    bool activated;
    public GameObject Wall, Entrance;
    public GameObject Number;
    int numberOfEnemies;

    private void Awake()
    {
        hasEntered = false;
        activated = false;

    }
    private void OnTriggerEnter2D(Collider2D collider) 
    {
        if (collider.gameObject.layer == LayerMask.NameToLayer("Player"))
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
                //RoomNumber.roomNum++;
                //roomNumber.NextRoom();
            }
            else
            {
                return;
            }
        }
    }
    private void Update()
    {
        if(numberOfEnemies == 0 && hasEntered) 
        {
            //roomNumber.HPtoMax();
            OpenTheDoors();
        }
        Testing();

    }
    public void OpenTheDoors()
    {

    }
    public void CloseTheDoors()
    {
        hasEntered = true;
    }
    private void Testing()
    {
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            OpenTheDoors();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            CloseTheDoors();
        }
    }
}
