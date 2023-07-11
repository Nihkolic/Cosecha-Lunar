using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorTrigger : MonoBehaviour
{
    bool hasEntered;
    LevelChange levelChange;
    [SerializeField] private int currentLevel;
    //[SerializeField] private Transform newPlayerPosition;

    [SerializeField] private Transform position_0;
    [SerializeField] private Transform position_1;
    [SerializeField] private Transform position_2;
    [SerializeField] private Transform position_3;

    private void Awake()
    {
        hasEntered = false;
        levelChange = GetComponentInParent<LevelChange>();
       
    }
    public void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            if (!hasEntered)
            {
                levelChange.ToNextLevel(currentLevel);
                LevelChangeDebug(currentLevel, collider.gameObject);
                hasEntered = true;
            }
            else
            {
                return;
            }
        }
    }
    public void LevelChangeDebug(int num, GameObject _player)
    {
        if (num == 0)
        {
            _player.transform.position = position_1.transform.position;
            print("Nivel 1");
        
            //gameAudio.PlayBackground(1);
        }
        if (num == 1)
        {

            _player.transform.position = position_2.transform.position;
            print("Nivel 2");
        
            //gameAudio.PlayBackground(1);
        }
        if (num == 2)
        {

            _player.transform.position = position_3.transform.position;
            print("Nivel 3");
      
            //gameAudio.PlayBackground(2);
        }
        if (num == 3)
        {

         
        }
    }
}
