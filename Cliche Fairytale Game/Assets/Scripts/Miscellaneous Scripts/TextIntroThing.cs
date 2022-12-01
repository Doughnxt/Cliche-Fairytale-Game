using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextIntroThing : MonoBehaviour
{
    [SerializeField] private RangeCheck range;
    [SerializeField] private GameObject text;

    private void Update()
    {
        if (range.inRange)
        {
            text.SetActive(true);
        }
        else if (!range.inRange)
        {
            text.SetActive(false);
        }
    }
}
