using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScreen : MonoBehaviour
{
    [SerializeField] private GameObject credits;
    [SerializeField] private GameObject endText;
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
        StartCoroutine(EndScreenOperation());
    }

    IEnumerator EndScreenOperation()
    {
        yield return new WaitForSeconds(2f);
        anim.SetTrigger("Open");
        yield return new WaitForSeconds(1f);
        endText.SetActive(true);
        yield return new WaitForSeconds(3f);
        credits.SetActive(true);
    }
}
