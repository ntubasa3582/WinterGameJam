using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire_Bar : MonoBehaviour
{
    public float rotatespeed = 10;
    void FixedUpdate()
    {
        transform.Rotate(0, 0, rotatespeed);
    }
}
