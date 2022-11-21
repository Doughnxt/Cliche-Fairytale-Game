using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FairyRange : MonoBehaviour
{
    private bool interactedWithGate;
    [SerializeField] private FairyGate gate;
    

    public void InteractionWithGate()
    {
        if (!interactedWithGate)
        {
            gate.fairyCount++;
            interactedWithGate = true;
        }
    }
}
