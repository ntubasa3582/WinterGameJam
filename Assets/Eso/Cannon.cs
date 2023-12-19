using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    [SerializeField] public GameObject SHOT_POSITION;
    [SerializeField] public GameObject bullet;

    private float num;
    public float bullespeed;
    public float maxnum = 1;
  
    void FixedUpdate()
    {
        
        num += 0.02f;
        if(num >= maxnum)
        {
            BallShot(10, bullet);
            num = 0;
        }
    }
    void BallShot(float speed, GameObject bullet)
    {
        GameObject shotObj = Instantiate(bullet, SHOT_POSITION.transform.position, Quaternion.identity);
        Rigidbody2D rb = shotObj.GetComponent<Rigidbody2D>();

        rb.velocity = this.transform.right * bullespeed;
        shotObj.transform.eulerAngles = this.transform.eulerAngles + new Vector3(0, 0, 0);
    }
}
