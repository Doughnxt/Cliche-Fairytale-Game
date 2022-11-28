using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private CheckpointManager checkpointM;

    private void Start()
    {
        checkpointM = GameObject.FindObjectOfType<CheckpointManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            checkpointM.lastCheckpointPos = transform.position;
        }
    }
}
