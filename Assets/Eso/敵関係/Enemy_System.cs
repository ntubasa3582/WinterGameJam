using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_System : MonoBehaviour
{
    private RaycastHit2D ray;
    void Start()
    {
        
    }

    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast((Vector2)ray.origin, (Vector2)ray.direction, maxDistance, layerMask);

        //なにかと衝突した時だけそのオブジェクトの名前をログに出す
        if (hit.collider)
        {
            Debug.Log(hit.collider.gameObject.name);
        }
    }
}
