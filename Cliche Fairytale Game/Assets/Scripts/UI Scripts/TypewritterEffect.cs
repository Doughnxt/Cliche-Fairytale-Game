using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TypewritterEffect : MonoBehaviour
{
    [SerializeField] private float timeBtwChars = .1f;
    [SerializeField] private float timeBtwWords = 1;
    public string[] stringArray;
    [SerializeField] TextMeshProUGUI text;

    int i = 0;

    public void EndCheck()
    {
        if (i <= stringArray.Length - 1)
        {
            text.text = stringArray[i];
            StartCoroutine(ShowText());
        }
    }

    private IEnumerator ShowText()
    {
        text.ForceMeshUpdate();
        int totalVisableCharacters = text.textInfo.characterCount;
        int counter = 0;

        while (true)
        {
            int visibleCount = counter % (totalVisableCharacters + 1);
            text.maxVisibleCharacters = visibleCount;

            if (visibleCount >= totalVisableCharacters)
            {
                i += 1;
                Invoke("End Check", timeBtwWords);
                break;
            }
            counter += 1;
            yield return new WaitForSeconds(timeBtwChars);
        }
    }
}
