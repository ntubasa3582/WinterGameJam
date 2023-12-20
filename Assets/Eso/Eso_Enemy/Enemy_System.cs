using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy_System : MonoBehaviour
{
    public SpriteRenderer sp;

    public GameObject lightpos;
    public GameObject leftpos;

    public float length = 1;//ray‚Ì’·‚³
    public float speed = 1;
    public bool myDirections = true;

    void FixedUpdate()
    {
        Ray2D lightray = new Ray2D (lightpos.transform.position, Vector2.down);
        RaycastHit2D lighthit = Physics2D.Raycast((Vector2)lightray.origin, (Vector2)lightray.direction, length);
        if (!lighthit.collider && myDirections)
        {
            myDirections = false;
            Debug.Log("‰½‚à‚È‚¢");
        }
        Ray2D leftray = new Ray2D(leftpos.transform.position, Vector2.down);
        RaycastHit2D lefthit = Physics2D.Raycast((Vector2)leftray.origin, (Vector2)leftray.direction, length);
        if (!lefthit.collider && !myDirections)
        {
            myDirections = true;
            Debug.Log("‰½‚à‚È‚¢");
        }
        if (myDirections)
        {
            transform.Translate(0.02f * speed, 0, 0);
            sp.flipX = true;
        }
        if (!myDirections)
        {
            transform.Translate(-0.02f * speed, 0, 0);
            sp.flipX = false;
        }
    }
}
