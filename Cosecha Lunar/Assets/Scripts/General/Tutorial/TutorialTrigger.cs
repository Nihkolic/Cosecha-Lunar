using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialTrigger : MonoBehaviour
{
    bool hasEntered;
    Tutorial tutorial;
    public int tutorialNumber;

    private void Awake()
    {
        hasEntered = false;
        tutorial = GetComponentInParent<Tutorial>();
    }
    public void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            if (!hasEntered)
            {
                tutorial.ShowHint(tutorialNumber);
                Debug.Log("Entered");
                hasEntered = true;
            }
            else
            {
                return;
            }
        }
    }
}
