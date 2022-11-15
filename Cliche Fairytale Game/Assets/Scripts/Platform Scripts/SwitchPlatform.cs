using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchPlatform : MonoBehaviour
{
    private BoxCollider2D box;
    private SpriteRenderer sprite;
    private Color32 activatedColor = new Color32(105, 167, 190, 255);
    private Color32 deactivatedColor = new Color32(138, 125, 137, 255);
    [SerializeField] private bool defaultOn;
    [SerializeField] private float switchTimer = 2f;
    private bool active;
    private bool platformOn;
    private bool switchingEnabled;

    private void Start()
    {
        box = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        switchingEnabled = true;

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
        if (switchingEnabled)
        {
            StartCoroutine(SwitchState());
        }

        if (active)
        {
            box.enabled = true;
            sprite.color = activatedColor;

        }
        else if (!active)
        {
            box.enabled = false;
            sprite.color = deactivatedColor;

        }

        if (defaultOn)
        {
            if (platformOn)
            {
                active = true;
            }
            else if (!platformOn)
            {
                active = false;
            }
        }

        else if (!defaultOn)
        {
            if (platformOn)
            {
                active = false;
            }
            else if (!platformOn)
            {
                active = true;
            }
        }
    }

    private IEnumerator SwitchState()
    {
        switchingEnabled = false;
        platformOn = true;
        yield return new WaitForSeconds(switchTimer);
        platformOn = false;
        yield return new WaitForSeconds(switchTimer);
        switchingEnabled = true;
    }
}

