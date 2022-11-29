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
    [SerializeField] private int damage = 3;
    private bool downStrikeActive;

    private GameObject slashEffect1;
    private GameObject slashEffect2;

    [SerializeField] private GameObject slashEffect_right_1;
    [SerializeField] private GameObject slashEffect_right_2;
    [SerializeField] private GameObject slashEffect_left_1;
    [SerializeField] private GameObject slashEffect_left_2;

    [SerializeField] private AudioSource damageSound;
    [SerializeField] private AudioSource attackSound1;
    [SerializeField] private AudioSource attackSound2;

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
            slashEffect1 = slashEffect_left_1;
            slashEffect2 = slashEffect_left_2;
        }
        else if (player.movementEnabled && player.flipped == false)
        {
            attackPos = attackPoint2;
            slashEffect1 = slashEffect_right_1;
            slashEffect2 = slashEffect_right_2;
        }
        else if (downStrikeActive)
        {
            attackPos = attackPoint3;
            Attack();
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
                        attackSound1.Play();
                        anim.SetTrigger("Attack 1");
                        attackAnimation = true;
                    }
                    else if (attackAnimation == true)
                    {
                        attackSound2.Play();
                        anim.SetTrigger("Attack 2");
                        attackAnimation = false;
                    }
                    Attack();
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

    private void Attack()
    {
        //damage enemies
        Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, enemyLayer);
        for (int i = 0; i < enemiesToDamage.Length; i++)
        {
            if (enemiesToDamage[i].GetComponent<EnemyHealth>() != null)
            {
                enemiesToDamage[i].GetComponent<EnemyHealth>().currentHealth -= damage;
                damageSound.Play();
            }

            if (enemiesToDamage[i].GetComponent<Lever>() is not null)
            {
                enemiesToDamage[i].GetComponent<Lever>().Flick();
            }
        }
    }

    private void PlaySlashEffect1()
    {
        slashEffect1.GetComponent<Animator>().SetTrigger("Slash 1");
    }

    private void PlaySlashEffect2()
    {
        slashEffect2.GetComponent<Animator>().SetTrigger("Slash 2");
    }
}
