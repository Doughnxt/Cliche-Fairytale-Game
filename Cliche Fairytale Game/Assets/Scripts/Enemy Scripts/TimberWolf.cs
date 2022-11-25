using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimberWolf : MonoBehaviour
{
    [SerializeField] private RangeCheck range;
    [SerializeField] private float moveForce = 2f;
    [SerializeField] private float waitTime = 3f;

    [SerializeField] private Transform destination;
    [SerializeField] private Transform startPos;

    [SerializeField] private GameObject eyeGlow;

    private EnemyHealth health;
    private SpriteRenderer sprite;
    private BoxCollider2D box;
    private Animator animator;
    private bool activated;
    private bool reset;
    private bool startedMoving;
    private bool idle;

    private static readonly int Fade_In = Animator.StringToHash("Timber_Wolf_Fade_In");
    private static readonly int Fade_Out = Animator.StringToHash("Timber_Wolf_Fade_Out");
    private static readonly int Death = Animator.StringToHash("Timber_Wolf_Death");
    private static readonly int Default = Animator.StringToHash("Timber_Wolf_Default");
    private static readonly int Moving = Animator.StringToHash("Timber_Wolf_Run");
    private static readonly int Idle = Animator.StringToHash("Timber_Wolf_Idle");

    private void Start()
    {
        health = GetComponent<EnemyHealth>();
        sprite = GetComponent<SpriteRenderer>();
        box = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();

        idle = true;
        sprite.enabled = true;
        box.enabled = true;
        animator.CrossFade(Default, 0, 0);
    }
    private void FixedUpdate()
    {
        if (activated && !health.dead)
        {
            idle = false;
            box.enabled = true;
            if (!startedMoving)
            {
                animator.CrossFade(Moving, 0, 0);
            }
            Move();
        }

        if (reset)
        {
            activated = false;
            animator.CrossFade(Fade_In, 0, 0);
            startedMoving = false;
            box.enabled = true;
            idle = true;
            reset = false;
        }
    }

    private void Update()
    {
        if (range.inRange)
        {
            activated = true;
        }
        else if (!range.inRange && idle)
        {
            animator.CrossFade(Idle, 0, 0);
        }

        if (health.dead)
        {
            animator.CrossFade(Death, 0, 0);
            eyeGlow.SetActive(false);
        }
    }

    private void Move()
    {
        startedMoving = true;
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
        animator.CrossFade(Fade_Out, 0, 0);
        box.enabled = false;
        yield return new WaitForSeconds(1f);
        StartCoroutine(StopAtDestination());
    }
}
