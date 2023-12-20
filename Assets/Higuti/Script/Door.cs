using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    bool trigger = false;
    [SerializeField] Transform Gate1;
    [SerializeField] Transform Gate2;
    [SerializeField] Transform Player;
    [SerializeField] AudioSource _dooropen;
    void Start()
    {

    }

    void Update()
    {
        if (trigger)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                _dooropen.Play();
                StartCoroutine(Warp());
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
    IEnumerator Warp()
    {
        yield return new WaitForSeconds(0.5f);
        Player.transform.position = Gate2.position;
    }
}
