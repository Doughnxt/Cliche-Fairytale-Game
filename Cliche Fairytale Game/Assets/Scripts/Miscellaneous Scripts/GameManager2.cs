using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager2 : MonoBehaviour
{
    private static GameManager2 instance;
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
