using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderPlatform : MonoBehaviour
{
    [SerializeField] private float waitTime = .2f;
    private int value;
    private bool on;
    private PlatformEffector2D effector;

    private void Start()
    {
        effector = GetComponent<PlatformEffector2D>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S) || (Input.GetKeyDown(KeyCode.DownArrow)))
        {
            value++;
        }
        else if (Input.GetKey(KeyCode.S) || (Input.GetKey(KeyCode.DownArrow)))
        {
            value++;
        }

        if (value > 0 && !on)
        {
            StartCoroutine(FallThrough());
        }
    }

    private IEnumerator FallThrough()
    {
        on = true;
        effector.rotationalOffset = 180f;
        yield return new WaitForSeconds(waitTime);
        effector.rotationalOffset = 0f;
        value = 0;
        on = false;
    }

}
