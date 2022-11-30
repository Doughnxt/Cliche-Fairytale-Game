using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadStartScreenAgain : MonoBehaviour
{
    private SceneManagerObject sceneManager;

    private void OnEnable()
    {
        sceneManager = FindObjectOfType<SceneManagerObject>();
    }
    public void LoadStartScreen()
    {
        sceneManager.LoadFirstScene();
    }
}
