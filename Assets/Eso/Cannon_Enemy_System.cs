using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;

public class Cannon_Enemy_System : MonoBehaviour
{
    public SpriteRenderer sp;
    public Animator anime;

    public GameObject lightpos;
    public GameObject leftpos;

    public float length = 5;//ray‚Ì’·‚³
    public float speed = 1;
    public bool myDirections = true;
    public bool isdeath = false;

    [SerializeField] public GameObject SP1;
    [SerializeField] public GameObject SP2;
    [SerializeField] public GameObject SP3;
    [SerializeField] public GameObject SP4;
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
        if (num >= maxnum)
        {
            BallShot(10, bullet);
            num = 0;
        }
        if (myDirections && !isdeath)
        {
            transform.Translate(0.02f * speed, 0, 0);
            sp.flipX = true;
            Ray2D lightray = new Ray2D(lightpos.transform.position, Vector2.down);
            RaycastHit2D lighthit = Physics2D.Raycast((Vector2)lightray.origin, (Vector2)lightray.direction, length);
            if (!lighthit.collider) myDirections = false;
        }
        if (!myDirections && !isdeath)
        {
            transform.Translate(-0.02f * speed, 0, 0);
            sp.flipX = false;
            Ray2D leftray = new Ray2D(leftpos.transform.position, Vector2.down);
            RaycastHit2D lefthit = Physics2D.Raycast((Vector2)leftray.origin, (Vector2)leftray.direction, length);
            if (!lefthit.collider) myDirections = true;
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            anime.SetBool("death", true);
            isdeath = true;
        }
    }
    public void Enemy_Destroy()
    {
        Destroy(gameObject);
    }
    void BallShot(float speed, GameObject bullet)
    {
        GameObject shotObj = Instantiate(bullet, SP1.transform.position, Quaternion.identity);
        Rigidbody2D rb = shotObj.GetComponent<Rigidbody2D>();
        SpriteRenderer sr = rb.GetComponent<SpriteRenderer>();
        int i = Random.Range(0, 3);
        switch (i)
        {
            case 1:
                sr.sprite = bullet1;
                break;
            case 2:
                sr.sprite = bullet2;
                break;
            case 3:
                sr.sprite = bullet3;
                break;
        }
        shotObj.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        if (myDirections)
        {
            sr.flipX = true;
            rb.velocity = this.transform.right * bullespeed;
            shotObj.transform.eulerAngles = this.transform.eulerAngles + new Vector3(0, 0, 0);
        }
        else
        {
            sr.flipX = false;
            rb.velocity = -this.transform.right * bullespeed;
            shotObj.transform.eulerAngles = this.transform.eulerAngles + new Vector3(0, 0, 0);
        }

        
    }
}
