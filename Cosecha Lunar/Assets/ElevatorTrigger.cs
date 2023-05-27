using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorTrigger : MonoBehaviour
{
    bool hasEntered;
    LevelChange levelChange;
    [SerializeField] private int currentLevel;
    [SerializeField] private Transform newPlayerPosition;
    private GameObject _player;
    private void Awake()
    {
        hasEntered = false;
        levelChange = GetComponentInParent<LevelChange>();
        _player = GameObject.FindWithTag("Player");
    }
    public void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            if (!hasEntered)
            {
                LevelEnd();
                _player.transform.position = newPlayerPosition.transform.position;
                Debug.Log(currentLevel + " End");
                hasEntered = true;
            }
            else
            {
                return;
            }
        }
    }
    void LevelEnd()
    {
        levelChange.ToNextLevel(currentLevel);
    }
}
