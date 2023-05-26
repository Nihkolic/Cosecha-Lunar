using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorTrigger : MonoBehaviour
{
    bool hasEntered;
    LevelChange levelChange;
    //public int tutorialNumber;
    [SerializeField] private LevelName level;
    public enum LevelName
    {
        Tutorial,
        Level01,
        Level02,
        Level03
    }
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
                LevelEnd();
                Debug.Log(level+" End");
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
        if (level == LevelName.Tutorial)
        {
            levelChange.ToNextLevel();
        }
        if (level == LevelName.Level01)
        {
            levelChange.ToNextLevel();
        }
        if (level == LevelName.Level02)
        {
            levelChange.ToNextLevel();
        }
        if (level == LevelName.Level03)
        {
            levelChange.LevelEnd();
        }
    }
}
