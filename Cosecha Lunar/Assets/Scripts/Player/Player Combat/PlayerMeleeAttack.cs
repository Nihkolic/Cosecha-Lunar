using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMeleeAttack : MonoBehaviour
{
    public float attackTimer = 1f;
    float _attackTimer;
    public Animator compAttack;

    public string animAttack1;
    public string animAttack2;
    public string animIdle;

    bool anim = false;
    [SerializeField] private PlayerAudio playerAudio;
    void Start()
    {
        //WeaponCollider.SetActive(false);
        _attackTimer = attackTimer;
    }

    void Update()
    {/*
        if (!PauseControl.gameIsPaused)
        {
            RandomAttack();
        }*/
        RandomAttack();
    }
    private void Attack(string attack, int num)
    {
        attackTimer -= Time.deltaTime;
        if (attackTimer < 0)
        {
            if (Input.GetMouseButtonDown(1) && !PauseMenu.GAME_IS_PAUSED)
            {
                compAttack.Play(animAttack1);
                playerAudio.PlayAttack();
                attackTimer = _attackTimer;
                anim = !anim;

                //PlayerCombat.rangedCam.SetActive(false);
                //PlayerCombat.rangedScript.SetActive(false);
            }
        }
    }
    void RandomAttack()
    {
        if (anim == false)
        {
            Attack(animAttack1, 1);

        }
        if (anim)
        {
            Attack(animAttack2, 2);

        }
    }

}