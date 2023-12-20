using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire_Bar : MonoBehaviour
{
    public bool direction = true;
    public float rotatespeed = 10;
    void FixedUpdate()
    {
        if (direction) transform.Rotate(0, 0, rotatespeed);
        if (!direction) transform.Rotate(0, 0, rotatespeed * -1);
    }
}
