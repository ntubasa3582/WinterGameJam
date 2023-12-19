using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_System : MonoBehaviour
{
    private RaycastHit2D lightray;
    private RaycastHit2D leftray;

    public GameObject lightpos;
    public GameObject leftpos;
    void Start()
    {
        
    }

    void FixedUpdate()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        float maxDistance = 10;
        RaycastHit2D hit = Physics2D.Raycast((Vector2)ray.origin, (Vector2)ray.direction, maxDistance);
        if (!hit.collider)
        {
            Debug.Log(hit.collider.gameObject.name);
        }
    }
}
