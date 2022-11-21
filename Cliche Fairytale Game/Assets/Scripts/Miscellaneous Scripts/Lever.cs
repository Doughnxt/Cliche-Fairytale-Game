using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Lever : MonoBehaviour
{
    private EnemyHealth health;
    public bool on;
    private bool leverOpen;
    private Animator anim;

    private void Start()
    {
        health = GetComponent<EnemyHealth>();
        anim = GetComponent<Animator>();
        on = false;
    }

    private void Update()
    {

        switch (health.currentHealth)
        {
            case 2:
                on = false;
                break;

            case 1:
                on = true;
                health.currentHealth = 3;
                break;

            default:
                break;
        }
    }

    public void Flick()
    {
        if (leverOpen)
        {
            anim.SetTrigger("Flick");
        }
        else
        {
            anim.SetTrigger("Flick 1");
        }
        leverOpen = !leverOpen;
    }
}
