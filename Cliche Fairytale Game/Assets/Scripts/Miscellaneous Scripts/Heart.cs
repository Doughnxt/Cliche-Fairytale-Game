using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{
    [SerializeField] private AudioSource sound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

            if (collision.GetComponent<PlayerHealth>() != null)
            {
                collision.GetComponent<PlayerHealth>().currentHealth = 4;
                collision.GetComponent<PlayerHealth>().UpdateHealth();
                StartCoroutine(Disappear());
            }
        }
    }

    private IEnumerator Disappear()
    {
        sound.Play();
        yield return new WaitForSeconds(.2f);
        this.gameObject.SetActive(false);
    }
}
