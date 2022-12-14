using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    [SerializeField] private Sprite onSprite;
    [SerializeField] private Sprite offSprite;
    [SerializeField] private AudioSource switchSound;
    private SpriteRenderer sprite;
    public bool on;

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        on = false;
        sprite.sprite = offSprite;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        switchSound.Play();
        if (on)
        {
            on = false;
            sprite.sprite = offSprite;
        }
        else if (!on)
        {
            on = true;
            sprite.sprite = onSprite;
        }
    }
}
