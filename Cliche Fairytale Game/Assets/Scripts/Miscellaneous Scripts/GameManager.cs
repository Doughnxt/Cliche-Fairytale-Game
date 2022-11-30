using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public AudioSource music;
    public AudioSource ambience;

    private bool musicPlaying;

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

        if (!musicPlaying)
        {
            music.Play();
            ambience.Play();
            musicPlaying = true;
        }
    }
}
