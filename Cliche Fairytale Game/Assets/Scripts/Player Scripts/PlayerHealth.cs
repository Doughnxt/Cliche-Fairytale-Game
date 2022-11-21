using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float iFramesDuration = 2;
    [SerializeField] float numberOfFlashes = 8;
    [SerializeField] GameObject healthThing_1;
    [SerializeField] GameObject healthThing_2;
    [SerializeField] GameObject healthThing_3;

    private SpriteRenderer sprite;
    private Animator anim;
    private PlayerMovement player;

    private int currentHealth;
    private int maxHealth = 3;

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        player = GetComponent<PlayerMovement>();
        currentHealth = maxHealth;
        Physics2D.IgnoreLayerCollision(15, 16, false);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            UpdateHealth();
        }
        else if (collision.gameObject.CompareTag("Hazard"))
        {
            Die();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            UpdateHealth();
        }
        else if (collision.gameObject.CompareTag("Hazard"))
        {
            Die();
        }
    }
    private IEnumerator Invunerability()
    {
        Physics2D.IgnoreLayerCollision(15, 16, true);
        for (int i = 0; i < numberOfFlashes; i++)
        {
            sprite.color = new Color(1, 1, 1, 0.5f);
            yield return new WaitForSeconds(iFramesDuration / (numberOfFlashes * 2));
            sprite.color = Color.white;
            yield return new WaitForSeconds(iFramesDuration / (numberOfFlashes * 2));
        }
        Physics2D.IgnoreLayerCollision(15, 16, false);
    }

    private void UpdateHealth()
    {
        currentHealth -= 1;
        StartCoroutine(Invunerability());

        if (currentHealth == 1)
        {
            healthThing_1.SetActive(true);
            healthThing_2.SetActive(false);
            healthThing_3.SetActive(false);
        }
        else if (currentHealth == 2)
        {
            healthThing_1.SetActive(true);
            healthThing_2.SetActive(true);
            healthThing_3.SetActive(false);
        }
        else if (currentHealth == 3)
        {
            healthThing_1.SetActive(true);
            healthThing_2.SetActive(true);
            healthThing_3.SetActive(true);
        }
        else if (currentHealth == 0)
        {
            Die();
        }
    }
    private void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void Die()
    {
        player.movementEnabled = false;
        anim.SetTrigger("Death");
    }
}
