using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopMusic : MonoBehaviour
{
    private void Awake()
    {
        GameObject[] musicObjects = GameObject.FindGameObjectsWithTag("Music");
        for (int i = 0; i < musicObjects.Length; i++)
        {
            musicObjects[i].SetActive(false);
        }
    }
}
