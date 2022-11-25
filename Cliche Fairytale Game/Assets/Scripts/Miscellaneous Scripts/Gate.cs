using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    private BoxCollider2D box;
    private Animator animator;
    private KeyCounter keyCounter;
    [SerializeField] private RangeCheck range;
    [SerializeField] private TypeOfGate type;
    [SerializeField] private Lever lever;
    [SerializeField] private Switch switch_;
    [SerializeField] private bool opened;

    private enum TypeOfGate { key, switch_, lever }

    void Start()
    {
        keyCounter = FindObjectOfType<KeyCounter>();
        box = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();

        if (opened)
        {
            Open();
        }
        else
        {
            Close();
        }
    }

    void Update()
    {
        switch (type)
        {
            case TypeOfGate.key:
                KeyGate();
                break;

            case TypeOfGate.switch_:
                SwitchGate();
                break;

            case TypeOfGate.lever:
                LeverGate();
                break;

            default:
                break;
        }
    }

    private void Open()
    {
        box.enabled = false;
        animator.SetTrigger("Open");
        opened = true;
    }

    private void Close()
    {
        box.enabled = true;
        animator.SetTrigger("Close");
        opened = false;
    }

    private void KeyGate()
    {
        if (!opened)
        {
            if (range.inRange)
            {
                if (Input.GetButtonDown("Interact"))
                {
                    if (keyCounter.keyCount > 0)
                    {
                        keyCounter.keyCount--;
                        Open();
                    }
                }
            }
        }
    }

    private void LeverGate()
    {

        if (!opened)
        {
            if (lever.on)
            {
                Open();
            }
        }
        else if (opened)
        {
            if (!lever.on)
            {
                Close();

            }
        }


    }

    private void SwitchGate()
    {
        if (!opened)
        {
            if (switch_.on)
            {
                Open();
            }
        }
        else if (opened)
        {
            if (!switch_.on)
            {
                Close();

            }
        }
    }
}
