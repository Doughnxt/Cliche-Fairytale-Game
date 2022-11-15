using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Up_DownPlatform : MonoBehaviour
{
    [SerializeField] private float moveForce = 2f;
    [SerializeField] private float waitTime = 3f;

    [SerializeField] private Transform destination;
    [SerializeField] private Transform startPos;

    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private BoxCollider2D box;
    private bool activated;
    private bool reset;



    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        box = GetComponent<BoxCollider2D>();

        sprite.enabled = true;
        box.enabled = true;
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
            sprite.enabled = true;
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
            StartCoroutine(StopAtDestination());
        }
    }
    private IEnumerator StopAtDestination()
    {
        yield return new WaitForSeconds(waitTime);
        sprite.enabled = false;
        box.enabled = false;
        yield return new WaitForSeconds(1f);
        transform.position = startPos.position;
        yield return new WaitForSeconds(1f);
        reset = true;
    }
}
