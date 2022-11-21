using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncyPlatform : MonoBehaviour
{
    [SerializeField] private float bouncePower = 20f;
    [SerializeField] private bool vertical = true;
    [SerializeField] private bool right = true;
    [SerializeField] private float bounceTime = 1f;
    private GameObject player;
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player = collision.gameObject;
            animator.SetTrigger("Bounce");

            //sideways bounce
            if (!vertical)
            {
                collision.gameObject.GetComponent<PlayerMovement>().movementEnabled = false;
                if (right)
                {
                    collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.right * bouncePower, ForceMode2D.Impulse);
                }
                else if (!right)
                {
                    collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.left * bouncePower, ForceMode2D.Impulse);
                }
            }

            //upwards bounce
            else if (vertical)
            {
                collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * bouncePower, ForceMode2D.Impulse);
            }
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (!vertical)
            {
                StartCoroutine(StopBounce());
            }
        }
    }

    private IEnumerator StopBounce()
    {
        yield return new WaitForSeconds(bounceTime);
        player.GetComponent<PlayerMovement>().movementEnabled = true;
    }

}
