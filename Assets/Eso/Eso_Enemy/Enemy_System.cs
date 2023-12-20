using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy_System : MonoBehaviour
{
    public AudioSource deatha;
    public SpriteRenderer sp;
    public Animator anime;

    public GameObject lightpos;
    public GameObject leftpos;

    public float length = 1;//ray‚Ì’·‚³
    public float speed = 1;
    public bool myDirections = true;
    public bool isdeath = false;

    void FixedUpdate()
    {
        if (myDirections && !isdeath)
        {
            transform.Translate(0.02f * speed, 0, 0);
            sp.flipX = true;
            Ray2D lightray = new Ray2D(lightpos.transform.position, Vector2.down);
            RaycastHit2D lighthit = Physics2D.Raycast((Vector2)lightray.origin, (Vector2)lightray.direction, length);

            if(!lighthit.collider) myDirections = false;
            else if(!lighthit.collider.gameObject.CompareTag("Ground") && !lighthit.collider.gameObject.CompareTag("Gimmick")) myDirections = false;
        }
        if (!myDirections && !isdeath)
        {
            transform.Translate(-0.02f * speed, 0, 0);
            sp.flipX = false;
            Ray2D leftray = new Ray2D(leftpos.transform.position, Vector2.down);
            RaycastHit2D lefthit = Physics2D.Raycast((Vector2)leftray.origin, (Vector2)leftray.direction, length);

            if (!lefthit.collider) myDirections = true;
            else if(!lefthit.collider.gameObject.CompareTag("Ground") && !lefthit.collider.gameObject.CompareTag("Gimmick")) myDirections = true;
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            deatha.Play();
            anime.SetBool("death", true);
            isdeath = true;
        }
    }
    public void Enemy_Destroy()
    {
        Destroy(gameObject);
    }
}
