using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordInStone : MonoBehaviour
{
    private GameObject player;
    [SerializeField] private float animationTime = 5f;
    [SerializeField] private RangeCheck range;
    private bool cutsceneActivated;
    private Animator anim;
    private SpriteRenderer sprite;
    private Vector2 endPosition = new Vector2(-17.44f, 12f);

    [SerializeField] private GameObject swordGlow;
    [SerializeField] private GameObject tutorialText;
    [SerializeField] private GameObject tutorialText2;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        cutsceneActivated = false;
        swordGlow.SetActive(true);
    }

    private void Update()
    {
        if (range.inRange)
        {
            //UI text stuff
            if (Input.GetButtonDown("Interact") && !cutsceneActivated)
            {
                cutsceneActivated = true;
                swordGlow.SetActive(false);
                player.GetComponent<PlayerMovement>().movementEnabled = false;
                player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                StartCoroutine(PlayCutscene());
            }
        }
    }

    private IEnumerator PlayCutscene()
    {
        player.GetComponent<SpriteRenderer>().enabled = false;
        anim.SetTrigger("Pull");
        tutorialText2.SetActive(false);
        player.GetComponent<Transform>().position = endPosition;
        yield return new WaitForSeconds(animationTime);
        sprite.enabled = false;
        tutorialText.SetActive(true);
        player.GetComponent<PlayerCombat>().enabled = true;
        player.GetComponent<SpriteRenderer>().enabled = true;
        player.GetComponent<PlayerMovement>().movementEnabled = true;
    }

}
