using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPositionReset : MonoBehaviour
{
    private CheckpointManager checkpointM;

    private void Start()
    {
        checkpointM = GameObject.FindObjectOfType<CheckpointManager>();
        transform.position = checkpointM.lastCheckpointPos;
    }
}
