using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearingPlatform : MonoBehaviour
{
    [SerializeField] private float disappearingTime = 1f;
    [SerializeField] private float standingTime = 1f;
    [SerializeField] private bool automatic = false;

    private BoxCollider2D box;
    private Animator anim;

    void Start()
    {
        box = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();

        box.enabled = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (automatic)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                StartCoroutine(Disappear());
            }
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (!automatic)
            {
                StartCoroutine(MagicTrick());
            }
        }
    }

    private IEnumerator MagicTrick()
    {
        anim.SetTrigger("Disappear");
        box.enabled = false;
        yield return new WaitForSeconds(disappearingTime);
        anim.SetTrigger("Reappear");
        box.enabled = true;
    }

    private IEnumerator Disappear()
    {
        yield return new WaitForSeconds(standingTime);
        StartCoroutine(MagicTrick());
    }

}
