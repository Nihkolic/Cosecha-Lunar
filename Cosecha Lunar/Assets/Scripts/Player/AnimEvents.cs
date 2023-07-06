using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimEvents : MonoBehaviour
{
    public Animator compAttack;
    public string animIdle;
    public void ResetAttack()
    {
        compAttack.Play(animIdle);
    }
    public void ToIddle() //nibler
    {
        GetComponent<Animator>().Play(animIdle);
    }

    public void ToIddleGunmen() 
    {
        GetComponent<Animator>().Play("Idle");
    }
}
