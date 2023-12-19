using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeeSaw : MonoBehaviour
{
    void Start()
    {
        
    }

    void FixedUpdate()
    {
        Debug.Log(this.transform.rotation.z);
    }
}
