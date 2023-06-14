using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorTrigger : MonoBehaviour
{
    bool hasEntered;
    LevelChange levelChange;
    [SerializeField] private int currentLevel;
    [SerializeField] private Transform newPlayerPosition;
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
                
                hasEntered = true;
            }
            else
            {
                return;
            }
        }
    }
}
