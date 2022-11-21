using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnOffSwitch : MonoBehaviour
{
    public static bool isOn;
    [SerializeField] private Sprite on;
    [SerializeField] private Sprite off;

    private SpriteRenderer sprite;

    private void Start()
    {
        isOn = true;
        sprite = GetComponent<SpriteRenderer>();
        sprite.sprite = on;
    }

    private void Update()
    {
        if (isOn)
        {
            sprite.sprite = on;
        }
        else if (!isOn)
        {
            sprite.sprite = off;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (isOn)
            {
                isOn = false;
            }
            else if (!isOn)
            {
                isOn = true;
            }
        }
    }

}
