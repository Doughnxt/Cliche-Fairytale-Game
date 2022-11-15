using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    private float timeBtwAttack;
    [SerializeField] private float startTimeBtwAttack;

    private PlayerMovement player;
    [SerializeField] private Transform attackPoint1;
    [SerializeField] private Transform attackPoint2;
    [SerializeField] private Transform attackPoint3;

    [SerializeField] private Transform attackPos;
    [SerializeField] private float attackRange;
    [SerializeField] private LayerMask enemyLayer;
    [SerializeField] private int damage = 1;
    private bool downStrikeActive;

    private bool attackAnimation;
    private Animator anim;

    private void Start()
    {
        attackPos = attackPoint1;
        anim = GetComponent<Animator>();
        player = GetComponent<PlayerMovement>();
        attackAnimation = false;
        downStrikeActive = false;
    }

    void Update()
    {
        //set attack hitbox
        if (player.movementEnabled && player.flipped == true)
        {
            attackPos = attackPoint1;
        }
        else if (player.movementEnabled && player.flipped == false)
        {
            attackPos = attackPoint2;
        }
        else if (downStrikeActive)
        {
            attackPos = attackPoint3;
        }

        //check if downstrike is finished
        if (!player.isFalling && downStrikeActive)
        {
            downStrikeActive = false;
            player.movementEnabled = true;
            anim.SetTrigger("Done Falling");
            //add particles for colliding with ground
        }


        if (player.movementEnabled)
        {
            if (Input.GetButtonDown("Attack"))
            {
                //downstrike
                if (player.isFalling)
                {
                    downStrikeActive = true;
                    player.movementEnabled = false;
                    anim.SetTrigger("Attack Down");
                }
                //regular attack
                if (timeBtwAttack <= 0)
                {
                    //play animation
                    if (attackAnimation == false)
                    {
                        anim.SetTrigger("Attack 1");
                        attackAnimation = true;
                    }
                    else if (attackAnimation == true)
                    {
                        anim.SetTrigger("Attack 2");
                        attackAnimation = false;
                    }

                    //damage enemies
                    Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, enemyLayer);
                    for (int i = 0; i < enemiesToDamage.Length; i++)
                    {
                        enemiesToDamage[i].GetComponent<EnemyHealth>().currentHealth -= damage;
                    }
                    timeBtwAttack = startTimeBtwAttack;
                }
            }
        }
        timeBtwAttack -= Time.deltaTime;

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.gray;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
}
