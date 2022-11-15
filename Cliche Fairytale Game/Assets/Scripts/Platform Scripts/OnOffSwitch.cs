using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnOffSwitch : MonoBehaviour
{
    public static bool isOn;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (isOn)
            {
                isOn = false;
            }
            else if (!isOn)
            {
                isOn = true;
            }
        }
    }

}
