using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public GameObject weapon;
    public Animator animator;
    public int selectedWeapon = 0;

    public static bool hasBlaster;
    public GameObject meleeCam;
    public GameObject meleeScript;
    public  GameObject rangedCam;
    public  GameObject rangedScript;

    [SerializeField] public static MovementState state;
    public enum MovementState //dashing, atacking
    {
        melee,
        ranged
    }
    private void Start()
    {
        Melee();
        hasBlaster = false;
    }
    void Update()
    {
        if (Input.GetAxis("Mouse ScrollWheel") != 0f)
        {
            if (hasBlaster)
            {
                if (state == MovementState.melee)
                {
                    Ranged();
                }
                else if (state == MovementState.ranged)
                {
                    Melee();
                }
            }
        }


    }
    void Melee()
    {
        state = MovementState.melee;
        meleeCam.SetActive(true);
        meleeScript.SetActive(true);

        rangedCam.SetActive(false);
        rangedScript.SetActive(false);
    }
    void Ranged()
    {
        state = MovementState.ranged;
        rangedCam.SetActive(true);
        rangedScript.SetActive(true);

        meleeCam.SetActive(false);
        meleeScript.SetActive(false);
    }
    public void BlasterGet()
    {
        hasBlaster = true;
        Ranged();
    }
    public void BlasterRevert()
    {
        hasBlaster = false;
        Melee();
    }
}
