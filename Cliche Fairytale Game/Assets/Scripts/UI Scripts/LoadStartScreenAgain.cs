using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadStartScreenAgain : MonoBehaviour
{
    private SceneManagerObject sceneManager;
    [SerializeField] private GameObject statsCanvas;

    private void OnEnable()
    {
        sceneManager = FindObjectOfType<SceneManagerObject>();
    }
    public void LoadStartScreen()
    {
        sceneManager.LoadFirstScene();
    }

    public void EnableStatsCanvas()
    {
        statsCanvas.SetActive(true);
        Cursor.visible = true;
    }
}
