using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class StatsText : MonoBehaviour
{
    private string text;
    private TextMeshProUGUI textMeshPro;

    private void OnEnable()
    {
        textMeshPro = GetComponent<TextMeshProUGUI>();
        text = $"Statistics<size=80%> <br> <br>Total time: {TimeSpan.FromSeconds(GameManager.totalGameTime)} <br> <br>Deaths: {GameManager.deathCount} <br> <br>Secrets found: {GameManager.secretCount}/1";
        textMeshPro.text = text;
    }


}
