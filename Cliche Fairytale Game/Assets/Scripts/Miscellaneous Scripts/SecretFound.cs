using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecretFound : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.secret1Found = true;
            Destroy(this.gameObject);
        }
    }
}
