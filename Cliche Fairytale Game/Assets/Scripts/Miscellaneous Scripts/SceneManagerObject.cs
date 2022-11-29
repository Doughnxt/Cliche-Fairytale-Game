using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerObject : MonoBehaviour
{
    private SceneTransitions transition;

    private void Start()
    {
        transition = FindObjectOfType<SceneTransitions>();
    }
    public void ReloadScene()
    {
        transition.ReloadCurrentScene();
    }

    public void LoadTheNextScene()
    {
        transition.LoadNextScene();
    }

    public void LoadFirstScene()
    {
        //load first scene
    }
}
