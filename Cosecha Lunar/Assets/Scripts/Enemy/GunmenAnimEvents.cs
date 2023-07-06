using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunmenAnimEvents : MonoBehaviour
{
    [SerializeField] private Gunmen gunmen;
    public void ToIddleGunmen()
    {
        GetComponent<Animator>().Play("Idle");
    }
    public void GunmenAttack()
    {
        gunmen.GunmenShoot();
    }
}
