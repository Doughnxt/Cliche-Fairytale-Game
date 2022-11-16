using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class KeyCounter : MonoBehaviour
{
    public int keyCount;
    private TextMeshProUGUI text;

    private void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        keyCount = 0;
    }

    void Update()
    {
        text.text = $"x{keyCount}";
    }
}
