using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnOffPlatform : MonoBehaviour
{
    [SerializeField] private bool defaultOn;
    private bool active;
    private BoxCollider2D box;
    private SpriteRenderer sprite;
    private Color32 onColor = new Color32(105, 178, 128, 255);
    private Color32 offColor = new Color32(80, 80, 80, 255);

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
            sprite.color = onColor;

        }
        else if (!active)
        {
            box.enabled = false;
            sprite.color = offColor;

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
