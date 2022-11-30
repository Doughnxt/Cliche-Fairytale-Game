using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateFireballs : MonoBehaviour
{
    [SerializeField] private GameObject[] fireballs;
    [SerializeField] private bool isFlame;
    [SerializeField] private float burnTime = 3f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            for (int i = 0; i < fireballs.Length; i++)
            {
                fireballs[i].gameObject.SetActive(true);
            }
            if (isFlame)
            {
                StartCoroutine(Flame());
            }
        }
    }
    private IEnumerator Flame()
    {
        yield return new WaitForSeconds(burnTime);
        for (int i = 0; i < fireballs.Length; i++)
        {
            fireballs[i].gameObject.SetActive(false);
        }
    }
}
