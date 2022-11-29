using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadNewScene : MonoBehaviour
{
private SceneManagerObject sceneManager;

    private void Start()
    {
        sceneManager = FindObjectOfType<SceneManagerObject>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            sceneManager.LoadTheNextScene();
        }
    }
}
