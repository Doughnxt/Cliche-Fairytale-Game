using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FairyManager : MonoBehaviour
{
    private static FairyManager instance;
    public Fairy[] fairies;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Update()
    {
        for (int i = 0; i < fairies.Length; i++)
        {
            if (fairies[i].collected)
            {
                fairies[i].startsByPlayer = true;
            }
        }
    }


}
