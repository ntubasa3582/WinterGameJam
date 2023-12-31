using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door2 : MonoBehaviour
{
    /// <summary>ドア開かない時の音</summary>
    [SerializeField] AudioSource _CloseSound;
    bool trigger = false;
    [SerializeField] Transform Gate1;
    [SerializeField] Transform Gate2;
    void Start()
    {
    }

    void Update()
    {
        if (trigger)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                _CloseSound.Play();
            }
        }
    }
    void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.CompareTag("Player"))
        {
            trigger = true;
            Debug.Log("接触");
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            trigger = false;
    }
}
