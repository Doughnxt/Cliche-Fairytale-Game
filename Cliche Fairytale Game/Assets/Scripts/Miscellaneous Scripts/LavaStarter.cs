using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaStarter : MonoBehaviour
{
    [SerializeField] private GameObject lava;
    private AudioSource music;
    private BoxCollider2D box;

    private void Start()
    {
        music = GetComponent<AudioSource>();
        box = GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            music.Play();
            lava.SetActive(true);
            box.enabled = false;
        }
    }
}
