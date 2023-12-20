using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    [SerializeField] public GameObject SHOT_POSITION;
    [SerializeField] public GameObject bullet;
    [SerializeField] Sprite bullet1 = null;
    [SerializeField] Sprite bullet2 = null;
    [SerializeField] Sprite bullet3 = null;

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
        SpriteRenderer sr = rb.GetComponent<SpriteRenderer>();
        /*
        Random.Range(0,3);
        switch
            case 1:
                sr.color = Color.white;
                break; 
            case 2:
                sr.color = Color.white;
                break;
            case 3:
                sr.color = Color.white;
                break;
        )
        */
        sr.sprite = bullet1;
        rb.velocity = this.transform.right * bullespeed;
        shotObj.transform.eulerAngles = this.transform.eulerAngles + new Vector3(0, 0, 0);
    }
}
