using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth;
    [SerializeField] private bool isBlock;
    public int currentHealth;
    private int previousHealthValue;
    private BoxCollider2D box;
    private SpriteRenderer sprite;
    private Animator animator;

    private void Start()
    {
        box = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();

        box.enabled = true;
        currentHealth = maxHealth;
        previousHealthValue = currentHealth;
    }
    private void Update()
    {
        Die();
        CheckHealth();
    }

    private void Die()
    {
        if (currentHealth <= 0)
        {
            box.enabled = false;
        }
    }

    private void CheckHealth()
    {
        if (currentHealth < previousHealthValue)
        {
            if (!isBlock)
            {
                //particles or flash or something
            }
            previousHealthValue = currentHealth;
        }
    }
}
