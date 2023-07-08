using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimEvents : MonoBehaviour
{
    public Animator compAttack;
    public string animIdle;
    public PlayerRangedAttack playerRanged;
    public void ResetAttack()
    {
        compAttack.Play(animIdle);
    }
    public void BlasterLower()
    {
        playerRanged.PlayDown();
    }
    public void BlasterUp()
    {
        playerRanged.PlayUp();
    }
    public void ToIddle() //nibler
    {
        GetComponent<Animator>().Play(animIdle);
    }

    public void ToIddleGunmen() 
    {
        GetComponent<Animator>().Play("Idle");
    }
    public void ChangeAnimation()
    {
        GetComponent<Animator>().Play(animIdle);
    }
}
