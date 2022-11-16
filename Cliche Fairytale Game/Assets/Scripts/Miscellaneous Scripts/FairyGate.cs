using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FairyGate : MonoBehaviour
{
    private BoxCollider2D box;
    private SpriteRenderer sprite;
    public int fairyCount;
    [SerializeField] private int fairiesNeededToOpen = 1;

    private void Start()
    {
        box = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();

        fairyCount = 0;
        sprite.enabled = true;
        box.enabled = true;
    }

    private void Update()
    {
        if (fairyCount == fairiesNeededToOpen)
        {
            OpenGate();
        }
    }

    private void OpenGate()
    {
        //play animation
        sprite.enabled = false;
        box.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Fairy Range"))
        {
            collision.gameObject.GetComponent<FairyRange>().InteractionWithGate();
        }
    }


}
