using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goblin : MonoBehaviour
{
    [SerializeField] private RangeCheck range;

    private Animator anim;
    private Transform player;
    private EnemyHealth health;

    [SerializeField] private float speed = 2f;
    Vector2 posLastFrame;
    Vector2 posThisFrame;
    private SpriteRenderer sprite;
    private bool hasDied;
    private Rigidbody2D rb;

    enum Direction { Right, Left, Still };
    private Direction direction;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        health = gameObject.GetComponent<EnemyHealth>();
    }

    private void Update()
    {
        if (health.dead && !hasDied)
        {
            rb.bodyType = RigidbodyType2D.Static;
            anim.SetTrigger("Death");
            hasDied = true;
        }

        if (range.inRange)
        {
            anim.SetBool("Attacking", true);
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
        else
        {
            anim.SetBool("Attacking", false);
        }

        posLastFrame = posThisFrame;

        posThisFrame = transform.position;

        CheckMoveDirection();
        if (direction == Direction.Right)
        {
            sprite.flipX = true;
        }
        else if (direction == Direction.Left)
        {
            sprite.flipX = false;
        }
    }

    Direction CheckMoveDirection()
    {
        if (posThisFrame.x > posLastFrame.x)
        {
            direction = Direction.Right;
            return Direction.Right;
        }
        if (posThisFrame.x < posLastFrame.x)
        {
            direction |= Direction.Left;
            return Direction.Left;
        }
        else
            return Direction.Still;
    }
}
