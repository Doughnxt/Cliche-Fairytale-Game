using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FairyRange : MonoBehaviour
{
    private bool interactedWithGate;
    [SerializeField] private FairyGate gate;
    
    private void Start()
    {
        Physics2D.IgnoreLayerCollision(14,15, true);
    }

    public void InteractionWithGate()
    {
        if (!interactedWithGate)
        {
            gate.fairyCount++;
            interactedWithGate = true;
        }
    }
}
