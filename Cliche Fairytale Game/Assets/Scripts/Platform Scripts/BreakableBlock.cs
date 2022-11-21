using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableBlock : MonoBehaviour
{
    private EnemyHealth health;
    private Animator anim;
    private SpriteRenderer spriteRenderer;
    private bool notDestroyed;
    [SerializeField] private Sprite slightlyBroken;
    [SerializeField] private Sprite veryBroken;

    private void Start()
    {
        notDestroyed = true;
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        health = GetComponent<EnemyHealth>();
    }

    private void Update()
    {
        switch (health.currentHealth)
        {
            case 2:
                spriteRenderer.sprite = slightlyBroken;
                break;

            case 1:
                spriteRenderer.sprite = veryBroken;
                break;

            case 0:
                if (notDestroyed)
                {
                    notDestroyed = false;
                    anim.SetTrigger("Break");
                }
                break;

            default:
                break;
        }
    }
}
