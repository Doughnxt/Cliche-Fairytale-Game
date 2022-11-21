using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fairy : MonoBehaviour
{
    [SerializeField] private RangeCheck range;
    [SerializeField] private float stoppingDistance = 1f;
    [SerializeField] private float speed = 3f;
    Vector2 posLastFrame;
    Vector2 posThisFrame;
    private Transform player;
    private bool followPlayer;
    private SpriteRenderer sprite;

    enum Direction { Right, Left, Still };
    private Direction direction;

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        Physics2D.IgnoreLayerCollision(14, 15, true);
        Physics2D.IgnoreLayerCollision(14, 18, true);
        Physics2D.IgnoreLayerCollision(14, 16, true);
    }

    private void Update()
    {
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

        if (range.inRange)
        {
            followPlayer = true;
        }

        if (followPlayer)
        {
            if (Vector2.Distance(transform.position, player.position) > stoppingDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            }
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
