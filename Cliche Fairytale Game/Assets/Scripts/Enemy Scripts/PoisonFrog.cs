using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonFrog : MonoBehaviour
{
    [SerializeField] private float jumpInterval = 1f;
    [SerializeField] private float jumpForce = 3f;
    [SerializeField] private float fallMultiplier = 3.5f;
    private bool isJumping;
    private bool active;
    private Rigidbody2D rb;
    private Animator anim;
    private EnemyHealth health;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        health = GetComponent<EnemyHealth>();

        active = true;
        anim.SetBool("Fall", false);
    }

    private void Update()
    {
        if (!isJumping)
        {
            StartCoroutine(Jump());
        }

        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
            anim.SetBool("Fall", true);
        }
        else if (rb.velocity.y > -.1f)
        {
            anim.SetBool("Fall", false);
        }

        if (health.dead && active)
        {
            active = false;
            StopAllCoroutines();
            anim.SetTrigger("Death");
        }
    }

    private IEnumerator Jump()
    {
        isJumping = true;
        anim.SetTrigger("Jump");
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        yield return new WaitForSeconds(jumpInterval);
        isJumping = false;
    }
}
