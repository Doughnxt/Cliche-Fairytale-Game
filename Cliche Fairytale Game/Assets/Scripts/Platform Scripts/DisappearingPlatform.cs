using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearingPlatform : MonoBehaviour
{
    [SerializeField] private float disappearingTime = 1f;
    [SerializeField] private float standingTime = 1f;
    [SerializeField] private bool automatic = false;

    private SpriteRenderer sprite;
    private BoxCollider2D box;

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        box = GetComponent<BoxCollider2D>();

        sprite.enabled = true;
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
            StartCoroutine(MagicTrick());
        }
    }

    private IEnumerator MagicTrick()
    {
        sprite.enabled = false;
        box.enabled = false;
        yield return new WaitForSeconds(disappearingTime);
        sprite.enabled = true;
        box.enabled = true;
    }

    private IEnumerator Disappear()
    {
        yield return new WaitForSeconds(standingTime);
        StartCoroutine(MagicTrick());
    }

}
