using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakingVines : MonoBehaviour
{
    private bool isbroken;
    private EnemyHealth health;
    private Animator anim;
    private BoxCollider2D box;
    [SerializeField] private float waitTime = 2f;

    private void Start()
    {
        health = GetComponent<EnemyHealth>();
        anim = GetComponent<Animator>();
        box = GetComponent<BoxCollider2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!isbroken)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                isbroken = true;
                StartCoroutine(BreakVines());
            }
        }
    }

    private IEnumerator BreakVines()
    {
        yield return new WaitForSeconds(waitTime);
        anim.SetTrigger("Break");
        box.enabled = false;
    }

    private void Update()
    {
        if (health.dead && !isbroken)
        {
            isbroken = true;
            anim.SetTrigger("Break");
        }
    }
}
