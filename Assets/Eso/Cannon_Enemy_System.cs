using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;

public class Cannon_Enemy_System : MonoBehaviour
{
    public AudioSource shotaudio;
    public AudioClip clip;

    public SpriteRenderer spriteRen;
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
    [SerializeField] public GameObject SP5;
    [SerializeField] public GameObject bullet;
    [SerializeField] Sprite bullet1 = null;
    [SerializeField] Sprite bullet2 = null;
    [SerializeField] Sprite bullet3 = null;
    [SerializeField] Sprite bullet4 = null;
    [SerializeField] Sprite bullet5 = null;

    private float num;
    public float size = 0.04f;
    public int shot_order = 1;
    public float bullespeed;
    public float maxnum = 1;

    void FixedUpdate()
    {
        num += 0.02f;
        if (num >= maxnum)
        {
            switch (shot_order)
            {
                case 1:
                    BallShot(bullet,SP1);
                    shot_order++;
                    break;
                case 2:
                    BallShot(bullet, SP2);
                    shot_order++;
                    break;
                case 3:
                    BallShot(bullet, SP3);
                    shot_order++;
                    break;
                case 4:
                    BallShot(bullet, SP4);
                    shot_order++;
                    break;
                case 5:
                    BallShot(bullet, SP5);
                    shot_order = 1;
                    break;
            }
            num = 0;
        }
        if (myDirections && !isdeath)
        {
            transform.Translate(0.02f * speed, 0, 0);
            spriteRen.flipX = true;
            Ray2D lightray = new Ray2D(lightpos.transform.position, Vector2.down);
            RaycastHit2D lighthit = Physics2D.Raycast((Vector2)lightray.origin, (Vector2)lightray.direction, length);

            if (!lighthit.collider) myDirections = false;
            else if (!lighthit.collider.gameObject.CompareTag("Ground") && !lighthit.collider.gameObject.CompareTag("Gimmick")) myDirections = false;
        }
        if (!myDirections && !isdeath)
        {
            transform.Translate(-0.02f * speed, 0, 0);
            spriteRen.flipX = false;
            Ray2D leftray = new Ray2D(leftpos.transform.position, Vector2.down);
            RaycastHit2D lefthit = Physics2D.Raycast((Vector2)leftray.origin, (Vector2)leftray.direction, length);

            if (!lefthit.collider) myDirections = true;
            else if (!lefthit.collider.gameObject.CompareTag("Ground") && !lefthit.collider.gameObject.CompareTag("Gimmick")) myDirections = true;
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
    void BallShot(GameObject bullet,GameObject SP)
    {
        shotaudio.PlayOneShot(clip);
        GameObject shotObj = Instantiate(bullet, SP.transform.position, Quaternion.identity);
        Rigidbody2D rb = shotObj.GetComponent<Rigidbody2D>();
        SpriteRenderer sr = rb.GetComponent<SpriteRenderer>();
        switch (shot_order)
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
            case 4:
                sr.sprite = bullet4;
                break;
            case 5:
                sr.sprite = bullet5;
                break;
        }
        shotObj.transform.localScale = new Vector3(size, size, size);
        if (myDirections)
        {
            sr.flipX = true;
            rb.velocity = this.transform.right * bullespeed;
            shotObj.transform.eulerAngles = this.transform.eulerAngles + new Vector3(0, 0, 0);
        }        else
        {
            sr.flipX = false;
            rb.velocity = -this.transform.right * bullespeed;
            shotObj.transform.eulerAngles = this.transform.eulerAngles + new Vector3(0, 0, 0);
        }

        
    }
}
