using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move_floor : MonoBehaviour
{
    public enum Patrolling { width, height, }
    public Patrolling patrolling;
    private Vector3 start_origin;
    [Header("--- soft—p ---")]
    public float move_speed;//ˆÚ“®‘¬“x

    void Start()
    {
        start_origin = this.transform.position;
    }
    void FixedUpdate()
    {
        float sin = Mathf.Sin(Time.time);
        if (Patrolling.width == patrolling)
        {
            this.transform.position = new Vector3(start_origin.x + sin * move_speed
                                                  , start_origin.y
                                                  , start_origin.z);
        }
        if (Patrolling.height == patrolling)
        {
            this.transform.position = new Vector3(start_origin.x
                                                  , start_origin.y + sin * move_speed
                                                  , start_origin.z);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player")) other.transform.SetParent(transform);
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player")) other.transform.SetParent(null);
    }
}
