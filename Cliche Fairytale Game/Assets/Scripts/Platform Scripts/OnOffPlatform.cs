using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnOffPlatform : MonoBehaviour
{
    [SerializeField] private bool defaultOn;
    [SerializeField] private Sprite onSprite;
    [SerializeField] private Sprite offSprite;
    private bool active;
    private BoxCollider2D box;
    private SpriteRenderer sprite;


    private void Start()
    {
        box = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();

        if (defaultOn)
        {
            active = true;
        }
        else if (!defaultOn)
        {
            active = false;
        }
    }

    private void Update()
    {
        if (active)
        {
            box.enabled = true;
            sprite.sprite = onSprite;

        }
        else if (!active)
        {
            box.enabled = false;
            sprite.sprite = offSprite;

        }

        if (defaultOn)
        {
            if (OnOffSwitch.isOn)
            {
                active = true;
            }
            else if (!OnOffSwitch.isOn)
            {
                active = false;
            }
        }

        else if (!defaultOn)
        {
            if (OnOffSwitch.isOn)
            {
                active = false;
            }
            else if (!OnOffSwitch.isOn)
            {
                active = true;
            }
        }
    }
}
