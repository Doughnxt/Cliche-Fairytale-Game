using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    public AudioSource forestBackgroiundMusic;
    public AudioSource forestAmbience;

    private bool canPlayForestSounds;
    private bool soundsPlaying;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else
        {
            Destroy(gameObject);
        }

        if (SceneManager.GetActiveScene().buildIndex < 5 || SceneManager.GetActiveScene().buildIndex > 0)
        {
            canPlayForestSounds = true;
        }

        if (canPlayForestSounds && !soundsPlaying)
        {
            forestAmbience.Play();
            forestBackgroiundMusic.Play();
            soundsPlaying = true;
        }
    }
}
