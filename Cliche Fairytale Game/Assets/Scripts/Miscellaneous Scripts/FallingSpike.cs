using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingSpike : MonoBehaviour
{
    [SerializeField] private float raycastDistance = 3f;
    [SerializeField] private LayerMask playerLayer;
    [SerializeField] private AudioSource breakingSound;

    private Rigidbody2D rb;
    private BoxCollider2D box;
    private Animator anim;
    [SerializeField] private Transform startPos;

    private bool canFall;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        box = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();

        canFall = true;
        rb.gravityScale = 0;
    }

    private void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, raycastDistance, playerLayer);

        if (hit.collider != null && canFall)

        {
            Fall();
        }

        Debug.DrawRay(transform.position, Vector2.down * raycastDistance, Color.red);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        canFall = false;
        StartCoroutine(ReturnToStart());
        if (collision.gameObject.CompareTag("Player"))

        {
            collision.gameObject.GetComponent<PlayerHealth>().currentHealth -= 2;
        }

        else if (collision.gameObject.CompareTag("Enemy"))

        {
            if (collision.gameObject.GetComponent<EnemyHealth>() != null)
            {
                collision.gameObject.GetComponent<EnemyHealth>().currentHealth--;
            }
        }

    }

    private void Fall()
    {
        rb.gravityScale = 1;
    }

    private IEnumerator ReturnToStart()
    {
        box.enabled = false;
        breakingSound.Play();
        anim.SetTrigger("Broken");
        rb.gravityScale = 0;
        yield return new WaitForSeconds(1f);
        transform.position = startPos.position;
        box.enabled = true;
        canFall = true;
        anim.SetTrigger("Reset");
    }
}


