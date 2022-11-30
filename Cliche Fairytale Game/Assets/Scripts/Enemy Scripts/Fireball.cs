using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float moveForce = 20f;

    private void OnEnable()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(Vector2.up * moveForce, ForceMode2D.Impulse);
    }
}
