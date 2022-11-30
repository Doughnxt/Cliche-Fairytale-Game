using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitions : MonoBehaviour
{
    private Animator animator;
    [SerializeField] private float transitionTime = 1f;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void ReloadCurrentScene()
    {
        StartCoroutine(TransitionToSelf());

    }

    public void LoadNextScene()
    {
        StartCoroutine(TransitionToNext());
    }

    public void LoadFirstScene()
    {
        StartCoroutine(TransitionToFirst());
    }


    private IEnumerator TransitionToSelf()
    {
        animator.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private IEnumerator TransitionToNext()
    {
        animator.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private IEnumerator TransitionToFirst()
    {
        animator.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene("Title_Screen");
    }
}
