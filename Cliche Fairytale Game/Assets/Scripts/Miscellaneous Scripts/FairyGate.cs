using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FairyGate : MonoBehaviour
{
    private BoxCollider2D box;
    private Animator animator;
    public int fairyCount;
    private bool opened;
    [SerializeField] private int fairiesNeededToOpen = 1;
    [SerializeField] private GameObject gateLight;

    private void Start()
    {
        opened = false;
        box = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();

        fairyCount = 0;
        box.enabled = true;
        gateLight.SetActive(true);
    }

    private void Update()
    {
        if (fairyCount >= fairiesNeededToOpen)
        {
            if (!opened)
            {
                StartCoroutine(OpenGate());
            }
        }
    }

    private IEnumerator OpenGate()
    {
        opened = true;
        gateLight.SetActive(false);
        animator.SetTrigger("Open");
        yield return new WaitForSeconds(1f);
        box.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Fairy Range"))
        {
            collision.gameObject.GetComponent<FairyRange>().InteractionWithGate();
        }
    }


}
