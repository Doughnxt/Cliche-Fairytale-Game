using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    private CircleCollider2D circle;
    private SpriteRenderer sprite;
    private KeyCounter keyCounter;
    [SerializeField] private GameObject keyLight;
    [SerializeField] private AudioSource keySound;

    private void Start()
    {
        circle = GetComponent<CircleCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        keyCounter = FindObjectOfType<KeyCounter>();

        circle.enabled = true;
        sprite.enabled = true;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            keySound.Play();
            keyLight.SetActive(false);
            circle.enabled = false;
            sprite.enabled = false;
            keyCounter.keyCount++;
        }
    }
}
