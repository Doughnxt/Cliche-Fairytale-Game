using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fairy : MonoBehaviour
{
    [SerializeField] private RangeCheck range;
    [SerializeField] private float stoppingDistance = 1f;
    [SerializeField] private float speed = 3f;
    [SerializeField] private AudioSource fairySounds;
    Vector2 posLastFrame;
    Vector2 posThisFrame;
    private Transform player;
    public bool followPlayer;
    private SpriteRenderer sprite;
    public bool collected;
    public bool startsByPlayer;
    private Vector3 playerPos;

    enum Direction { Right, Left, Still };
    private Direction direction;

    private void Start()
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").transform.position;
        if (startsByPlayer)
        {
            transform.position = playerPos;
        }

        fairySounds.Play();
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
            collected = true;
            followPlayer = true;
            fairySounds.volume = .5f;
        }
        else
        {
            fairySounds.volume = 0;
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
