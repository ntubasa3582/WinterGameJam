using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spring_Board : MonoBehaviour
{
    public float jumpForce = 5;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Rigidbody2D rb = collision.GetComponent<Rigidbody2D>();
            rb.velocity = Vector3.zero;
            rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
        }
    }
}
