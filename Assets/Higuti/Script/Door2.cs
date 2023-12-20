using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door2 : MonoBehaviour
{
    /// <summary>ÉhÉAäJÇ©Ç»Ç¢éûÇÃâπ</summary>
    [SerializeField] AudioSource _doorSound;
    bool trigger = false;
    [SerializeField] Transform Gate1;
    [SerializeField] Transform Gate2;
    void Start()
    {
        _doorSound = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (trigger)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                _doorSound.Play();
            }
        }
    }
    void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.CompareTag("Player"))
        {
            trigger = true;
            Debug.Log("ê⁄êG");
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            trigger = false;
    }
}
