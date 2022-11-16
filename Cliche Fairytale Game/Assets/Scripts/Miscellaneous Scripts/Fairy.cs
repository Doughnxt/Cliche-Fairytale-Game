using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fairy : MonoBehaviour
{
    [SerializeField] private RangeCheck range;
    [SerializeField] private float stoppingDistance = 1f;
    [SerializeField] private float speed = 3f;
    private Transform player;
    private bool followPlayer;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        Physics2D.IgnoreLayerCollision(14, 15, true);   
    }

    private void Update()
    {
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
}
