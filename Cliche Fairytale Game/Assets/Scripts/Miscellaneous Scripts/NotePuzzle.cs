using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotePuzzle : MonoBehaviour
{
    [SerializeField] private GameObject objectToDropOnSwitch;
    public static int currentNoteValue;
    public static int noteCount;
    private static bool correctOrderInput;
    private static bool puzzleOrderCorrect;

    private void Start()
    {
        objectToDropOnSwitch.SetActive(false);
    }

    private void Update()
    {
        switch (noteCount)
        {
            case 1:
                if (currentNoteValue == 1)
                {
                    correctOrderInput = true;
                }
                else
                {
                    noteCount = 0;
                    correctOrderInput = false;
                }
                break;

            case 2:
                if (currentNoteValue == 3)
                {
                    correctOrderInput = true;
                }
                else
                {
                    noteCount = 0;
                    correctOrderInput = false;
                }
                break;

            case 3:
                if (currentNoteValue == 2)
                {
                    correctOrderInput = true;
                }
                else
                {
                    noteCount = 0;
                    correctOrderInput = false;
                }
                break;

            case 4:
                if (currentNoteValue == 0)
                {
                    correctOrderInput = true;
                    puzzleOrderCorrect = true;
                }
                else
                {
                    noteCount = 0;
                    correctOrderInput = false;
                }
                break;

            default:
                break;
        }

        if (correctOrderInput && puzzleOrderCorrect)
        {
            objectToDropOnSwitch.SetActive(true);
        }
    }
}
