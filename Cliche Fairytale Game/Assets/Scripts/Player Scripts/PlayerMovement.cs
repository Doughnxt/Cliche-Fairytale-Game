using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //movement variables
    [SerializeField] private float speed = 3;
    private float direction;
    public bool flipped;
    public bool isFalling;
    public bool movementEnabled = true;

    //jump variables
    [SerializeField] private float jumpStrength = 7f;
    [SerializeField] private float fallMultiplier = 3.5f;
    [SerializeField] private LayerMask groundLayer;
    private bool canJump = true;


    //compenent variables
    private BoxCollider2D coll;
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private Animator anim;

    //sound variables
    [SerializeField] private AudioSource walkingSound;
    private bool playingSound;


    //enums
    private enum MovementState { idle, running, jumping, falling }


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        coll = GetComponent<BoxCollider2D>();
        movementEnabled = true;
    }

    void Update()
    {
        Jump();
        Debug.DrawRay(coll.bounds.center, Vector2.down, Color.green);
        if (IsGrounded())
        {
            isFalling = false;
        }
    }

    private void FixedUpdate()
    {
        Movement();
    }

    private void Movement()
    {
        if (movementEnabled)
        {
            if (rb.velocity.y < 0)
            {
                rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
            }

            MovementState state;
            direction = Input.GetAxis("Horizontal");

            if (direction > 0f)
            {
                if (IsGrounded())
                {
                    if (!playingSound)
                    {
                        walkingSound.Play();
                        playingSound = true;
                    }
                }
                else
                {
                    playingSound = false;
                    walkingSound.Stop();
                }
                rb.velocity = new Vector2(direction * speed, rb.velocity.y);
                state = MovementState.running;
                sprite.flipX = false;
                flipped = false;
            }
            else if (direction < 0f)
            {
                if (IsGrounded())
                {
                    if (!playingSound)
                    {
                        walkingSound.Play();
                        playingSound = true;
                    }
                }
                else
                {
                    playingSound = false;
                    walkingSound.Stop();
                }
                rb.velocity = new Vector2(direction * speed, rb.velocity.y);
                state = MovementState.running;
                sprite.flipX = true;
                flipped = true;
            }
            else
            {
                playingSound = false;
                walkingSound.Stop();
                rb.velocity = new Vector2(0, rb.velocity.y);
                state = MovementState.idle;
            }

            if (rb.velocity.y > .1f)
            {
                state = MovementState.jumping;
                isFalling = false;
            }
            else if (rb.velocity.y < -.1f)
            {
                state = MovementState.falling;
                isFalling = true;
            }
            else if (rb.velocity.y == 0)
            {
                isFalling = false;
            }

            anim.SetInteger("MoveState", (int)state);
        }
    }

    private void Jump()
    {
        if (movementEnabled)
        {
            if (canJump == true)
            {
                if (Input.GetButtonDown("Jump") && IsGrounded())
                {
                    rb.velocity = Vector2.up * jumpStrength;
                }
            }
        }
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0.1f, Vector2.down, .1f, groundLayer);
    }
}
