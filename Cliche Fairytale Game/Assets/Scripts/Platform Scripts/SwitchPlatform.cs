using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchPlatform : MonoBehaviour
{
    private BoxCollider2D box;
    private SpriteRenderer sprite;
    [SerializeField] private bool defaultOn;
    [SerializeField] private float switchTimer = 2f;
    [SerializeField] private Sprite redOnSprite;
    [SerializeField] private Sprite redOffSprite;
    [SerializeField] private Sprite blueOnSprite;
    [SerializeField] private Sprite blueOffSprite;

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
            sprite.sprite = blueOnSprite;
        }
        else if (!defaultOn)
        {
            active = false;
            sprite.sprite = redOffSprite;
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

        }
        else if (!active)
        {
            box.enabled = false;


        }

        if (defaultOn)
        {
            if (platformOn)
            {
                active = true;
                sprite.sprite = blueOnSprite;
            }
            else if (!platformOn)
            {
                active = false;
                sprite.sprite = blueOffSprite;
            }
        }

        else if (!defaultOn)
        {
            if (platformOn)
            {
                active = false;
                sprite.sprite = redOffSprite;
            }
            else if (!platformOn)
            {
                active = true;
                sprite.sprite = redOnSprite;
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

