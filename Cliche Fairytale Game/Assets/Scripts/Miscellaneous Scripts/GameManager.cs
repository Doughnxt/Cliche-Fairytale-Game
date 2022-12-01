using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static float totalGameTime;
    public static bool secret1Found;
    public static int deathCount;
    public static bool timerGoing;
    public static int secretCount;

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
    }

    private void Update()
    {
        if (Time.timeScale > 0 && timerGoing)
        {
            totalGameTime += Time.deltaTime;
        }
        if (secret1Found)
        {
            secretCount = 1;
        }
    }
}
