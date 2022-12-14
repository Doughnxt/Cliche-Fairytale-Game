using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float iFramesDuration = 2;
    [SerializeField] float numberOfFlashes = 8;
    [SerializeField] AudioSource damageSound;
    private GameObject healthThing_1;
    private GameObject healthThing_2;
    private GameObject healthThing_3;
    private SceneManagerObject sceneManager;

    private SpriteRenderer sprite;
    private Animator anim;
    private PlayerMovement player;
    private Rigidbody2D rb;

    public int currentHealth;
    private int maxHealth = 3;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        player = GetComponent<PlayerMovement>();
        currentHealth = maxHealth;
        Physics2D.IgnoreLayerCollision(15, 16, false);

        rb.bodyType = RigidbodyType2D.Dynamic;
        healthThing_1 = GameObject.Find("Health Point 1");
        healthThing_2 = GameObject.Find("Health Point 2");
        healthThing_3 = GameObject.Find("Health Point 3");
        sceneManager = GameObject.FindObjectOfType<SceneManagerObject>();
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            damageSound.Play();
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
            damageSound.Play();
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

    public void UpdateHealth()
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

    private void Die()
    {
        rb.bodyType = RigidbodyType2D.Static;
        player.movementEnabled = false;
        anim.SetTrigger("Death");
        GameManager.deathCount++;
    }

    private void ReloadCurrentScene()
    {
        sceneManager.ReloadScene();
    }

}
