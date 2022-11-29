using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
   [SerializeField] private GameObject pauseMenu;
   [SerializeField] private GameObject controlsScreen;
    private SceneManagerObject sceneManager;
    private bool paused;

    private void Start()
    {
        pauseMenu.SetActive(false);
        controlsScreen.SetActive(false);
        Cursor.visible = false;
        sceneManager = FindObjectOfType<SceneManagerObject>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!paused)
            {
                Pause();
            }
            else
            {
                Unpause();
            }
        }
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);
        Cursor.visible = true;
        paused = true;
    }

    public void Unpause()
    {
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
        controlsScreen.SetActive(false);
        Cursor.visible = false;
        paused = false;
    }

    public void ReloadCurrentScene()
    {
        Unpause();
        sceneManager.ReloadScene();
    }

    public void LoadStartScreen()
    {
        Unpause();
        sceneManager.LoadFirstScene();
    }

    public void ShowControlScreen()
    {
        pauseMenu.SetActive(false);
        controlsScreen.SetActive(true);
    }

    public void ExitControlsScreen()
    {
        pauseMenu.SetActive(true);
        controlsScreen.SetActive(false);
    }
}
