using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroy2 : MonoBehaviour
{
    private AudioSource music;


    private void Awake()
    {
        music = GetComponent<AudioSource>();
    }

    private void FixedUpdate()
    {
        if (music.volume < .8f)
        {
            music.volume += 0.005f;
        }
    }
}
