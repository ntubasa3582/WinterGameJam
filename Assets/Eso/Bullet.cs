using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float num;
    public float max = 5;
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        num += 0.02f;
        if(num > max)
        {
            Destroy(this.gameObject);
        }
    }
}
