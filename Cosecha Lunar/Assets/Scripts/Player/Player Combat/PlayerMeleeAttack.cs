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
    //public AttackSfx attackSfx;
    void Start()
    {
        //WeaponCollider.SetActive(false);
        _attackTimer = attackTimer;
    }

    void Update()
    {
        if (!PauseControl.gameIsPaused)
        {
            RandomAttack();
        }
    }
    private void Attack(string attack, int num)
    {
        attackTimer -= Time.deltaTime;
        if (attackTimer < 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                compAttack.Play(animAttack1);
                //attackSfx.PlayAttack(num);
                attackTimer = _attackTimer;
                anim = !anim;
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