using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    private BoxCollider2D box;
    private SpriteRenderer sprite;
    private KeyCounter keyCounter;
    [SerializeField] private RangeCheck range;

    void Start()
    {
        keyCounter = FindObjectOfType<KeyCounter>();
        box = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();

        box.enabled = true;
        sprite.enabled = true;
    }

    void Update()
    {
        if (range.inRange)
        {
            if (Input.GetButtonDown("Open"))
            {
                if (keyCounter.keyCount > 0)
                {
                    keyCounter.keyCount--;
                    Open();
                }
            }
        }
    }

    private void Open()
    {
        box.enabled = false;
        sprite.enabled = false;
    }
}
