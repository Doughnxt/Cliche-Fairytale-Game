using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Up_DownPlatform : MonoBehaviour
{
    [SerializeField] private float moveForce = 2f;
    [SerializeField] private float waitTime = 3f;

    [SerializeField] private Transform destination;
    [SerializeField] private Transform startPos;

    [SerializeField] private AudioSource disappearingSound;
    [SerializeField] private AudioSource reappearingSound;

    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private BoxCollider2D box;
    private Animator animator;
    private bool activated;
    private bool reset;

    private static readonly int Directional_Disappear = Animator.StringToHash("Directional_Disappear");
    private static readonly int Directional_Reappear = Animator.StringToHash("Directional_Reappear");
    private static readonly int Default_Directional = Animator.StringToHash("Default_Directional");



    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        box = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();


        sprite.enabled = true;
        box.enabled = true;
        animator.CrossFade(Default_Directional, 0, 0);
    }
    private void FixedUpdate()
    {
        if (activated)
        {
            MovePlatform();
        }

        if (reset)
        {
            activated = false;
            animator.CrossFade(Directional_Reappear, 0, 0);
            box.enabled = true;
            reset = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.SetParent(transform);
            if (!activated)
            {
                activated = true;
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.SetParent(null);

        }
    }

    private void MovePlatform()
    {
        transform.position = Vector3.MoveTowards(transform.position, destination.position, moveForce * Time.deltaTime);

        if (transform.position == destination.position)
        {
            StartCoroutine(Disappear());
        }
    }
    private IEnumerator StopAtDestination()
    {
        transform.position = startPos.position;
        yield return new WaitForSeconds(1f);
        reset = true;
    }

    private IEnumerator Disappear()
    {
        yield return new WaitForSeconds(waitTime);
        animator.CrossFade(Directional_Disappear, 0, 0);
        box.enabled = false;
        yield return new WaitForSeconds(1f);
        StartCoroutine(StopAtDestination());
    }

    private void PlayDisappearingSound()
    {
        disappearingSound.Play();
    }

    private void PlayReappearingSound()
    {
        reappearingSound.Play();
    }


}
